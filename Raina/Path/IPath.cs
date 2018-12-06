namespace Raina.Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IPath
    {
        bool HasParentDirectory { get; }

        bool IsAbsolutePath { get; }

        bool IsDirectoryPath { get; }

        bool IsFilePath { get; }

        bool IsRelativePath { get; }

        IDirectoryPath ParentDirectoryPath { get; }

        PathMode PathMode { get; }

        bool IsChildOf(IDirectoryPath directory);
    }
}