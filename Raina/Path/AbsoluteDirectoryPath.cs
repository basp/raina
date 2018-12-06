namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class AbsoluteDirectoryPath : IAbsoluteDirectoryPath
    {
        private readonly string directoryName;
        private readonly IDriveLetter drive;
        private readonly string uncServer = string.Empty;
        private readonly string uncShare = string.Empty;

        public AbsoluteDirectoryPath(IDriveLetter drive, string directoryName)
        {
            this.drive = drive;
            this.directoryName = directoryName;
        }

        public AbsoluteDirectoryPath(string uncServer, string uncShare, string directoryName)
        {
            this.uncServer = uncServer;
            this.uncShare = uncShare;
            this.directoryName = directoryName;
        }

        public IReadOnlyList<IAbsoluteDirectoryPath> ChildDirectories => throw new NotImplementedException();

        public IReadOnlyList<IAbsoluteFilePath> ChildFiles => throw new NotImplementedException();

        public DirectoryInfo DirectoryInfo => throw new NotImplementedException();

        public IDriveLetter Drive => this.drive;

        public bool Exists => throw new NotImplementedException();

        public AbsolutePathKind Kind => throw new NotImplementedException();

        public IAbsoluteDirectoryPath ParentDirectoryPath => throw new NotImplementedException();

        public string UNCServer => this.uncServer;

        public string UNCShare => this.uncShare;

        public string DirectoryName => this.directoryName;

        public bool HasParentDirectory => !string.IsNullOrEmpty(this.directoryName);

        public bool IsAbsolutePath => true;

        public bool IsDirectoryPath => true;

        public bool IsFilePath => false;

        public bool IsRelativePath => false;

        public PathMode PathMode => PathMode.Absolute;

        IDirectoryPath IPath.ParentDirectoryPath => throw new NotImplementedException();

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