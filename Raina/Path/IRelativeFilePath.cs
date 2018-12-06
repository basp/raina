namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRelativeFilePath : IRelativePath, IFilePath, IPath
    {
        new IAbsoluteFilePath GetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory);

        new IRelativeDirectoryPath GetSiblingDirectoryWithName(string directoryName);

        new IRelativeFilePath GetSiblingFileWithName(string fileName);

        IRelativeFilePath WithExtension(string newExtension);
    }
}