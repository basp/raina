namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RelativeFilePath : IRelativeFilePath
    {
        public IRelativeDirectoryPath ParentDirectoryPath => throw new NotImplementedException();

        public string FileExtension => throw new NotImplementedException();

        public string FileName => throw new NotImplementedException();

        public string FileNameWithoutExtension => throw new NotImplementedException();

        public bool HasParentDirectory => throw new NotImplementedException();

        public bool IsAbsolutePath => throw new NotImplementedException();

        public bool IsDirectoryPath => throw new NotImplementedException();

        public bool IsFilePath => throw new NotImplementedException();

        public bool IsRelativePath => throw new NotImplementedException();

        public PathMode PathMode => throw new NotImplementedException();

        IDirectoryPath IPath.ParentDirectoryPath => throw new NotImplementedException();

        public bool CanGetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new NotImplementedException();
        }

        public IAbsoluteFilePath GetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new NotImplementedException();
        }

        public IRelativeDirectoryPath GetSiblingDirectoryWithName(string directoryName)
        {
            throw new NotImplementedException();
        }

        public IRelativeFilePath GetSiblingFileWithName(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool IsChildOf(IDirectoryPath directory)
        {
            throw new NotImplementedException();
        }

        public IRelativeFilePath WithExtension(string newExtension)
        {
            throw new NotImplementedException();
        }

        IAbsolutePath IRelativePath.GetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new NotImplementedException();
        }

        IDirectoryPath IFilePath.GetSiblingDirectoryWithName(string directoryName)
        {
            throw new NotImplementedException();
        }

        IFilePath IFilePath.GetSiblingFileWithName(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}