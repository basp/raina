namespace Raina.Path
{
    using System.Collections.Generic;
    using System.IO;
    using Optional;

    internal class Root : IAbsoluteDirectoryPath
    {
        public Root(IVolume volume)
        {
            this.Volume = volume;
        }

        public IVolume Volume { get; }

        public bool Exists => throw new System.NotImplementedException();

        public Option<IAbsoluteDirectoryPath> ParentDirectoryPath => throw new System.NotImplementedException();

        public bool HasParentDirectory => false;

        public bool IsAbsolutePath => true;

        public bool IsDirectoryPath => true;

        public bool IsFilePath => false;

        public bool IsRelativePath => false;

        public string FullPath => $@"{this.Volume.Name}{Path.DirectorySeparatorChar}";

        public PathMode Mode => PathMode.Absolute;

        public IReadOnlyList<IAbsoluteDirectoryPath> ChildDirectories => throw new System.NotImplementedException();

        public IReadOnlyList<IAbsoluteFilePath> ChildFiles => throw new System.NotImplementedException();

        public DirectoryInfo DirectoryInfo => throw new System.NotImplementedException();

        public Option<string> DirectoryName => throw new System.NotImplementedException();

        Option<IDirectoryPath> IPath.ParentDirectoryPath => throw new System.NotImplementedException();

        public bool CanGetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new System.NotImplementedException();
        }

        public IAbsoluteDirectoryPath GetChildDirectoryWithName(string directoryName)
        {
            throw new System.NotImplementedException();
        }

        public IAbsoluteFilePath GetChildFileWithName(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public IRelativePath GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new System.NotImplementedException();
        }

        public IAbsoluteDirectoryPath GetSiblingDirectoryWithName(string directoryName)
        {
            throw new System.NotImplementedException();
        }

        public IAbsoluteFilePath GetSiblingFileWithName(string fileName)
        {
            throw new System.NotImplementedException();
        }

        public bool IsChildOf(IDirectoryPath directory)
        {
            throw new System.NotImplementedException();
        }

        public bool OnSameVolumeThan(IAbsolutePath other)
        {
            throw new System.NotImplementedException();
        }

        IDirectoryPath IDirectoryPath.GetChildDirectoryWithName(string directoryName)
        {
            throw new System.NotImplementedException();
        }

        IFilePath IDirectoryPath.GetChildFileWithName(string fileName)
        {
            throw new System.NotImplementedException();
        }

        IRelativeDirectoryPath IAbsoluteDirectoryPath.GetRelativePathFrom(IAbsoluteDirectoryPath pivotDirectory)
        {
            throw new System.NotImplementedException();
        }

        IDirectoryPath IDirectoryPath.GetSiblingDirectoryWithName(string directoryName)
        {
            throw new System.NotImplementedException();
        }

        IFilePath IDirectoryPath.GetSiblingFileWithName(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}