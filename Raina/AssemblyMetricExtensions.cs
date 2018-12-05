namespace Raina
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;

    public static class AssemblyMetrics
    {
        public static int Ca(this AssemblyDefinition self) => 0;

        public static int Ce(this AssemblyDefinition self) => 0;

        public static int NbLinesOfCode(this AssemblyDefinition self) =>
            self.Modules
                .SelectMany(x => x.Types)
                .SelectMany(x => x.Methods)
                .Sum(x => x.NbLinesOfCode());
    }
}
