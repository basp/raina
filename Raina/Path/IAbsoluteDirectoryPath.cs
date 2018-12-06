namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public interface IAbsoluteDirectoryPath : IAbsolutePath, IDirectoryPath, IPath
    {
        IReadOnlyList<IAbsoluteDirectoryPath> ChildDirectories { get; }

        IReadOnlyList<IAbsoluteFilePath> ChildFiles { get; }

        DirectoryInfo DirectoryInfo { get; }

        new IAbsoluteDirectoryPath GetChildDirectoryWithName(string directoryName);

        new IAbsoluteFilePath GetChildFileWithName(string fileName);

        new IAbsoluteDirectoryPath GetSiblingDirectoryWithName(string directoryName);

        new IAbsoluteFilePath GetSiblingFileWithName(string fileName);

        new IRelativeDirectoryPath GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory);
    }
}