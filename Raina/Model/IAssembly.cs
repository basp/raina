namespace Raina.Model
{
    using System;
    using System.Collections.Generic;

    public interface IAssembly : ICodeContainer, ICodeElement, ICodeElementParent
    {
        IEnumerable<IAssembly> AssembliesUsed { get; }

        IEnumerable<IAssembly> AssembliesUsingMe { get; }

        string FilePath { get; }

        bool HasProgramDatabase { get; }

        int NumberOfNamespaces { get; }

        int NumberOfTypesUsed { get; }

        int NumberOfTypesUsingMe { get; }

        Version Version { get; }

        string ProjectFilePath { get; }
    }
}