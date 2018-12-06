namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class AbsoluteFilePath : IAbsoluteFilePath
    {
        public FileInfo FileInfo => throw new NotImplementedException();

        public IDriveLetter Drive => throw new NotImplementedException();

        public bool Exists => throw new NotImplementedException();

        public AbsolutePathKind Kind => throw new NotImplementedException();

        public IAbsoluteDirectoryPath ParentDirectoryPath => throw new NotImplementedException();

        public string UNCServer => throw new NotImplementedException();

        public string UNCShare => throw new NotImplementedException();

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

        public bool CanGetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new NotImplementedException();
        }

        public IRelativeFilePath GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new NotImplementedException();
        }

        public IAbsoluteDirectoryPath GetSiblingDirectoryWithName(string directoryName)
        {
            throw new NotImplementedException();
        }

        public IAbsoluteFilePath GetSiblingFileWithName(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool IsChildOf(IDirectoryPath directory)
        {
            throw new NotImplementedException();
        }

        public bool OnSameVolumeThan(IAbsolutePath other)
        {
            throw new NotImplementedException();
        }

        public IAbsoluteFilePath WithExtension(string newExtension)
        {
            throw new NotImplementedException();
        }

        IRelativePath IAbsolutePath.GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory)
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