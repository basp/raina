namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRelativeDirectoryPath : IDirectoryPath, IRelativePath, IPath
    {
        new IAbsoluteDirectoryPath GetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory);

        new IRelativeDirectoryPath GetSiblingDirectoryWithName(string directoryName);

        new IRelativeFilePath GetSiblingFileWithName(string fileName);

        new IRelativeDirectoryPath GetChildDirectoryWithName(string directoryName);

        new IRelativeFilePath GetChildFileWithName(string fileName);
    }
}