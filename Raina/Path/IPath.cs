namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Optional;

    public interface IPath
    {
        bool HasParentDirectory { get; }

        bool IsAbsolutePath { get; }

        bool IsDirectoryPath { get; }

        bool IsFilePath { get; }

        bool IsRelativePath { get; }

        string FullPath { get; }

        Option<IDirectoryPath> ParentDirectoryPath { get; }

        PathMode Mode { get; }

        bool IsChildOf(IDirectoryPath directory);
    }
}