namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using Optional;

    internal class RelativeDirectoryPath : IRelativeDirectoryPath
    {
        public RelativeDirectoryPath(string path)
        {
            this.DirectoryName = Option.Some(Path.GetDirectoryName(path));
            this.FullPath = path;
        }

        public Option<string> DirectoryName { get; }

        public string FullPath { get; }

        public Option<IRelativeDirectoryPath> ParentDirectoryPath =>
            DirectoryName.Map(x => (IRelativeDirectoryPath)new RelativeDirectoryPath(x));

        public bool HasParentDirectory => false;

        public bool IsAbsolutePath => false;

        public bool IsDirectoryPath => true;

        public bool IsFilePath => false;

        public bool IsRelativePath => true;

        public PathMode Mode => PathMode.Relative;

        Option<string> IDirectoryPath.DirectoryName { get; }

        Option<IDirectoryPath> IPath.ParentDirectoryPath { get; }

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