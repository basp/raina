namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RelativeDirectoryPath : IRelativeDirectoryPath
    {
        public string DirectoryName => throw new NotImplementedException();

        public IRelativeDirectoryPath ParentDirectoryPath => throw new NotImplementedException();

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

        public IAbsoluteDirectoryPath GetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new NotImplementedException();
        }

        public IRelativeDirectoryPath GetChildDirectoryWithName(string directoryName)
        {
            throw new NotImplementedException();
        }

        public IRelativeFilePath GetChildFileWithName(string fileName)
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

        IAbsolutePath IRelativePath.GetAbsolutePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new NotImplementedException();
        }

        IDirectoryPath IDirectoryPath.GetChildDirectoryWithName(string directoryName)
        {
            throw new NotImplementedException();
        }

        IFilePath IDirectoryPath.GetChildFileWithName(string fileName)
        {
            throw new NotImplementedException();
        }

        IDirectoryPath IDirectoryPath.GetSiblingDirectoryWithName(string directoryName)
        {
            throw new NotImplementedException();
        }

        IFilePath IDirectoryPath.GetSiblingFileWithName(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}