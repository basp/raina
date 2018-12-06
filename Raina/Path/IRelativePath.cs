namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRelativePath : IPath
    {
        new IRelativeDirectoryPath ParentDirectoryPath { get; }
        
        bool CanGetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory);

        IAbsolutePath GetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory);
    }
}