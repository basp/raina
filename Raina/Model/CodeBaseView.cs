namespace Raina
{
    using System.Collections.Generic;
    using Mono.Cecil;
    using Raina.Model;

    public class CodeBaseView : ICodeBaseView
    {
        private readonly AssemblyDefinition[] assemblies;

        public CodeBaseView(params AssemblyDefinition[] assemblies)
        {
            this.assemblies = assemblies;
        }

        public void Analyze()
        {
        }

        public IEnumerable<IAssembly> Assemblies => throw new System.NotImplementedException();

        public IEnumerable<ICodeContainer> CodeContainers => throw new System.NotImplementedException();

        public IEnumerable<ICodeElementParent> CodeElementParents => throw new System.NotImplementedException();

        public IEnumerable<ICodeElement> CodeElements => throw new System.NotImplementedException();

        public IEnumerable<IField> Fields => throw new System.NotImplementedException();

        public IEnumerable<IMember> Members => throw new System.NotImplementedException();

        public IEnumerable<IMethod> Methods => throw new System.NotImplementedException();

        public IEnumerable<INamespace> Namesspaces => throw new System.NotImplementedException();

        public IEnumerable<IType> Types => throw new System.NotImplementedException();

        public IEnumerable<IMember> TypesAndMembers => throw new System.NotImplementedException();
    }
}