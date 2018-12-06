namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Optional;

    public interface IDirectoryPath : IPath
    {
        Option<string> DirectoryName { get; }

        IDirectoryPath GetSiblingDirectoryWithName(string directoryName);

        IFilePath GetSiblingFileWithName(string fileName);

        IDirectoryPath GetChildDirectoryWithName(string directoryName);

        IFilePath GetChildFileWithName(string fileName);
    }
}