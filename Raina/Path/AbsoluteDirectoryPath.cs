namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Optional;

    internal class AbsoluteDirectoryPath : IAbsoluteDirectoryPath
    {
        public AbsoluteDirectoryPath(IVolume volume, string path)
        {
            this.Volume = volume;
            this.DirectoryName = Option.Some(Path.GetDirectoryName(path));
            this.FullPath = path;
        }

        public IReadOnlyList<IAbsoluteDirectoryPath> ChildDirectories => throw new NotImplementedException();

        public IReadOnlyList<IAbsoluteFilePath> ChildFiles => throw new NotImplementedException();

        public DirectoryInfo DirectoryInfo => new DirectoryInfo(this.FullPath);

        public bool Exists => this.DirectoryInfo.Exists;

        public Option<IAbsoluteDirectoryPath> ParentDirectoryPath =>
            Option.None<IAbsoluteDirectoryPath>();
            // new AbsoluteDirectoryPath(this.Volume, this.DirectoryName);

        public Option<string> DirectoryName { get; }

        public string FullPath { get; }

        public bool HasParentDirectory => this.DirectoryName.HasValue;

        public bool IsAbsolutePath => true;

        public bool IsDirectoryPath => true;

        public bool IsFilePath => false;

        public bool IsRelativePath => false;

        public PathMode Mode => PathMode.Absolute;

        public IVolume Volume { get; }

        Option<IDirectoryPath> IPath.ParentDirectoryPath => throw new NotImplementedException();

        public bool CanGetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new NotImplementedException();
        }

        public IAbsoluteDirectoryPath GetChildDirectoryWithName(string directoryName)
        {
            throw new NotImplementedException();
        }

        public IAbsoluteFilePath GetChildFileWithName(string fileName)
        {
            throw new NotImplementedException();
        }

        public IRelativeDirectoryPath GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory)
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

        IDirectoryPath IDirectoryPath.GetChildDirectoryWithName(string directoryName)
        {
            throw new NotImplementedException();
        }

        IFilePath IDirectoryPath.GetChildFileWithName(string fileName)
        {
            throw new NotImplementedException();
        }

        IRelativePath IAbsolutePath.GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory)
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