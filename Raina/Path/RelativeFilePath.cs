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

        public bool HasParentDirectory => true;

        public bool IsAbsolutePath => false;

        public bool IsDirectoryPath => false;

        public bool IsFilePath => true;

        public bool IsRelativePath => true;

        public PathMode PathMode => PathMode.Relative;

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