namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public interface IAbsoluteFilePath : IAbsolutePath, IFilePath, IPath
    {
        FileInfo FileInfo { get; }

        new IAbsoluteDirectoryPath GetSiblingDirectoryWithName(string directoryName);   

        new IAbsoluteFilePath GetSiblingFileWithName(string fileName);

        new IRelativeFilePath GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory);

        IAbsoluteFilePath WithExtension(string newExtension);
    }
}