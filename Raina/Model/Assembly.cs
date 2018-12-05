namespace Raina.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Mono.Cecil;

    public class Assembly : IAssembly
    {
        private readonly AssemblyDefinition definition;

        public Assembly(AssemblyDefinition definition)
        {
            this.definition = definition;
        }

        public void Analyze(ICodeBaseView view)
        {
            
        }

        public IEnumerable<IAssembly> AssembliesUsed => throw new NotImplementedException();

        public IEnumerable<IAssembly> AssembliesUsingMe => throw new NotImplementedException();

        public string FilePath { get; }

        public bool HasProgramDatabase => throw new NotImplementedException();

        public int NumberOfNamespaces => throw new NotImplementedException();

        public int NumberOfTypesUsed => throw new NotImplementedException();

        public int NumberOfTypesUsingMe => throw new NotImplementedException();

        public Version Version { get; }

        public string ProjectFilePath => throw new NotImplementedException();

        private static Version GetVersion(AssemblyDefinition d)
        {
            var attr = d.CustomAttributes.First(x => x.AttributeType.Name == "AssemblyFileVersionAttribute");
            return Version.Parse((string)attr.ConstructorArguments.First().Value);
        }
    }
}