namespace Raina
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;

    public static class Extensions
    {
        // The number of scopes in a method.
        public static int ILNestingDepth(this MethodDefinition method) =>
            // We can reasonbly guestimate this by just counting the number 
            // of conditional branch instructions in the body.
            method.Body.Instructions
                .Where(x => x.IsConditionalBranchInstruction())
                .Count();

        // The number of methods that depend on this method.
        // External methods are not counted.
        public static int MethodCa(this MethodDefinition method) =>
            method.Module.Assembly.Modules
                .SelectMany(x => x.Types)
                .SelectMany(x => x.Methods)
                .Where(x => x.HasBody)
                .Where(x => x.DependsOn(method))
                .Count();

        // The number of methods that this method depends on.
        // External methods are counted.
        public static int MethodCe(this MethodDefinition method) =>
            method.Body.Instructions
                .Where(x => x.IsMethodCall())
                .Where(x => x.HasWellKnownCallOperand())
                .Select(x => x.GetOperandMethodFullName())
                // Doing a distinct on the method's full name isn't really
                // very elegant but it works well.
                .Distinct()
                .Count();

        public static int CCIL(this MethodDefinition method) =>
            method.Body.Instructions
                .Where(x => x.IsBranchInstruction())
                .Select(x => (Instruction)x.Operand)
                .Select(x => x.Offset)
                .Distinct()
                .Count() + 1;

        // The only thing that makes this a little bit tricky is that we 
        // don't want to count the curly braces marking the beginning and 
        // end of scopes. As such, we dive into the source and do a pretty
        // ugly character check using the information from the pdb. 
        //
        // We memoize the whole reading-the-file thing to make it a bit 
        // faster during runtime at the expensive of a little bit of memory.
        //
        // NOTE: Since we're using the pdb this won't work at all when the 
        // pdb is not available.
        public static int NbLinesOfCode(this MethodDefinition method)
        {
            var memread = MemoizeReadDocument();
            return method.DebugInformation.SequencePoints
                .Select(x => new { Code = memread(x.Document.Url), Ins = x })
                // We sometimes get crazy (outlier) line numbers from Cecil (like 16234212 in a 
                // 96 line file) so let's just hack around this for now and pretend it did not 
                // happen...
                .Where(x => x.Code.IsValidLine(x.Ins.StartLine))
                // This is actually a pretty dirty way to skip around the scope markers but
                // it's straightforward and works well enough for C# based assemblies.
                .Select(x => x.Code.GetCharAt(x.Ins.StartLine, x.Ins.StartColumn))
                .Where(x => !x.IsScopeMarker())
                // This will give a pretty good indication of the actual lines of code without
                // any real biases.
                .Count();
        }

        private static string GetOperandMethodFullName(this Instruction self)
        {
            switch (self.Operand)
            {
                case MethodDefinition m:
                    return m.FullName;
                case GenericInstanceMethod m:
                    return m.FullName;
                case MethodReference m:
                    return m.FullName;
                default:
                    throw new ArgumentException();
            }
        }

        private static bool HasWellKnownCallOperand(this Instruction self)
        {
            switch (self.Operand)
            {
                case MethodDefinition m:
                    return true;
                case GenericInstanceMethod m:
                    return true;
                case MethodReference m:
                    return true;
                default:
                    return false;
            }
        }

        private static bool DependsOn(this MethodDefinition self, MethodDefinition other) =>
            // TODO: This seems to work... 
            // Why do we even need the ugly name hack in the `MethodCe` 
            // method above?
            self.Body.Instructions.Any(x => other.Equals(x.Operand));

        private static bool IsConditionalBranchInstruction(this Instruction self) =>
            self.OpCode.FlowControl == FlowControl.Cond_Branch;

        private static bool IsMethodCall(this Instruction self) =>
            self.OpCode.FlowControl == FlowControl.Call;

        private static bool IsBranchInstruction(this Instruction self) =>
            self.OpCode.FlowControl == FlowControl.Branch ||
            self.OpCode.FlowControl == FlowControl.Cond_Branch;

        private static bool IsScopeMarker(this char c) =>
            c.IsStartScopeMarker() || c.IsEndScopeMarker();

        private static bool IsStartScopeMarker(this char c) =>
            c == '{';

        private static bool IsEndScopeMarker(this char c) =>
            c == '}';

        private static bool IsValidLine(this IEnumerable<string> lines, int line) =>
            line >= 0 && line < lines.Count();

        // Line and col are one-based, substract one to indices
        private static char GetCharAt(this IEnumerable<string> lines, int line, int col) =>
            lines.ElementAt(line - 1).Substring(col - 1, 1)[0];

        private static IEnumerable<string> ReadDocument(this string path) =>
            File.ReadLines(path);

        private static Func<string, IEnumerable<string>> MemoizeReadDocument()
        {
            var mem = new ConcurrentDictionary<string, IList<string>>();
            return x => mem.GetOrAdd(x, ReadDocument(x).ToList());
        }
    }
}
