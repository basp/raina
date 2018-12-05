namespace Raina.Model
{
    using System;
    using System.Collections.Generic;

    public interface ICodeBaseView
    {
        IEnumerable<IAssembly> Assemblies { get; }

        IEnumerable<ICodeContainer> CodeContainers { get; }

        IEnumerable<ICodeElementParent> CodeElementParents { get; }

        IEnumerable<ICodeElement> CodeElements { get; }

        IEnumerable<IField> Fields { get; }

        IEnumerable<IMember> Members { get; }

        IEnumerable<IMethod> Methods { get; }

        IEnumerable<INamespace> Namesspaces { get; }

        IEnumerable<IType> Types { get; }

        IEnumerable<IMember> TypesAndMembers { get; }
    }
}