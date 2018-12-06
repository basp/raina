namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Optional;

    internal class AbsoluteFilePath : IAbsoluteFilePath
    {
        public AbsoluteFilePath(IVolume volume, string path)
        {
            this.Volume = volume;
            this.FileExtension = Path.GetExtension(path);
            this.FileName = Path.GetFileName(path);
            this.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            this.DirectoryName = Path.GetDirectoryName(path);
            this.FullPath = path;
        }

        public FileInfo FileInfo => new FileInfo(this.FullPath);

        public IVolume Volume { get; }

        public bool Exists => this.FileInfo.Exists;

        public IAbsoluteDirectoryPath ParentDirectoryPath =>
            new AbsoluteDirectoryPath(this.Volume, this.DirectoryName);

        public string FileExtension { get; }

        public string FileName { get; }

        public string FileNameWithoutExtension { get; }

        public string DirectoryName { get; }

        public string FullPath { get; }

        public bool HasParentDirectory => true;

        public bool IsAbsolutePath => true;

        public bool IsDirectoryPath => false;

        public bool IsFilePath => true;

        public bool IsRelativePath => false;

        public PathMode Mode => PathMode.Absolute;

        Option<IAbsoluteDirectoryPath> IAbsolutePath.ParentDirectoryPath => throw new NotImplementedException();

        Option<IDirectoryPath> IPath.ParentDirectoryPath => throw new NotImplementedException();

        Option<string> IFilePath.DirectoryName => throw new NotImplementedException();

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