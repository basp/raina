namespace Raina.Path
{
    using System;

    public static class PathHelpers
    {
        public static char[] InvalidPathChars = new[]
        {
            '<',
            '>',
            '"',
            '|',
            '?',
            '*',
            (char)0x00,
            (char)0x01,
            (char)0x02,
            (char)0x03,
            (char)0x04,
            (char)0x05,
            (char)0x06,
            (char)0x07,
            (char)0x08,
            (char)0x09,
            (char)0x0A,
            (char)0x0B,
            (char)0x0C,
            (char)0x0D,
            (char)0x0E,
            (char)0x0F,
            (char)0x10,
            (char)0x11,
            (char)0x12,
            (char)0x13,
            (char)0x14,
            (char)0x15,
            (char)0x16,
            (char)0x17,
            (char)0x18,
            (char)0x19,
            (char)0x1A,
            (char)0x1B,
            (char)0x1C,
            (char)0x1D,
            (char)0x1E,
            (char)0x1F,
        };

        public static bool IsValidAbsoluteDirectoryPath(string path)
        {
            throw new NotImplementedException();
        }

        public static bool IsValidAbsoluteFilePath(string path)
        {
            throw new NotImplementedException();
        }

        public static bool IsValidRelativeDirectoryPath(string path)
        {
            throw new NotImplementedException();
        }

        public static bool IsValidRelativeFilePath(string path)
        {
            throw new NotImplementedException();
        }

        public static bool IsValidDirectoryPath(string path)
        {
            throw new NotImplementedException();
        }

        public static bool IsValidFilePath(string path)
        {
            throw new NotImplementedException();
        }

        public static IAbsoluteDirectoryPath ToAbsoluteDirectoryPath(string path)
        {
            throw new NotImplementedException();
        }

        public static IAbsoluteFilePath ToAbsoluteFilePath(string path)
        {
            throw new NotImplementedException();
        }

        public static IDirectoryPath ToDirectoryPath(string path)
        {
            throw new NotImplementedException();
        }

        public static IFilePath ToFilePath(string path)
        {
            throw new NotImplementedException();
        }

        public static IRelativeDirectoryPath ToRelativeDirectoryPath(string path)
        {
            throw new NotImplementedException();
        }

        public static IRelativeFilePath ToRelativeFilePath(string path)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetAbsoluteDirectoryPath(
            string path,
            out IAbsoluteDirectoryPath absoluteDirectoryPath)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetAbsoluteFilePath(
            string path,
            out IAbsoluteFilePath absoluteFilePath)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetRelativeDirectoryPath(
            string path,
            out IRelativeDirectoryPath relativeDirectoryPath)
        {
            throw new NotImplementedException();
        }

        public static bool TryGetRelativeFilePath(
            string path,
            out IRelativeFilePath relativeFilePath)
        {
            throw new NotImplementedException();
        }
    }
}