namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Optional;

    public interface IAbsolutePath : IPath
    {
        IVolume Volume { get; }

        bool Exists { get; }        

        new Option<IAbsoluteDirectoryPath> ParentDirectoryPath { get; }

        bool CanGetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory);

        IRelativePath GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory);

        bool OnSameVolumeThan(IAbsolutePath other);
    }
}