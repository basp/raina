namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IAbsolutePath : IPath
    {
        IDriveLetter Drive { get; }

        bool Exists { get; }        

        AbsolutePathKind Kind { get; }

        new IAbsoluteDirectoryPath ParentDirectoryPath { get; }

        string UNCServer { get; }

        string UNCShare { get; }        

        bool CanGetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory);

        IRelativePath GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory);

        bool OnSameVolumeThan(IAbsolutePath other);
    }
}