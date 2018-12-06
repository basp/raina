namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Optional;

    public interface IRelativePath : IPath
    {
        new Option<IRelativeDirectoryPath> ParentDirectoryPath { get; }
        
        bool CanGetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory);

        IAbsolutePath GetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory);
    }
}