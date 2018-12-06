namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Optional;

    public interface IFilePath : IPath
    {
        string FileExtension { get; }

        string FileName { get; }

        string FileNameWithoutExtension { get; }

        Option<string> DirectoryName { get; }

        IDirectoryPath GetSiblingDirectoryWithName(string directoryName);

        IFilePath GetSiblingFileWithName(string fileName);
    }
}