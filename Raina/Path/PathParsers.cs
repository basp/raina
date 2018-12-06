namespace Raina.Path
{
    using System;
    using System.IO;
    using Superpower;
    using Superpower.Parsers;

    public static class PathParsers
    {
        static char[] InvalidPathChars = new char[]
        {
            '*',
            '?',
            '>',
            '<',
            '|',
            ':',
            (char)0x00,
        };

        static char[] InvalidFileNameChars = new char[]
        {
            '\\',
            '/',
            '*',
            '?',
            '>',
            '<',
            '|',
            ':',
            (char)0x00,
        };

        static TextParser<char> PathCharacter =
            Character.ExceptIn(InvalidPathChars);
        static TextParser<char> FileNameCharacter =
            Character.ExceptIn(InvalidFileNameChars);

        static TextParser<char> DirectorySeparator =
            Character.EqualTo(Path.DirectorySeparatorChar);

        static TextParser<char> AltDirectorySeparator =
            Character.EqualTo(Path.AltDirectorySeparatorChar);

        static TextParser<char> PathSeparator = 
            DirectorySeparator.Or(AltDirectorySeparator);

        static TextParser<string> FileName = 
            from chars in FileNameCharacter.AtLeastOnce()
            select new string(chars);

        private static TextParser<IVolume> ParseLogicalDisk =
            from drive in Character.Letter
            from _ in Character.EqualTo(':')
            select (IVolume)new LogicalDisk(drive);

        private static TextParser<IVolume> ParseNetworkShare =
            from host in FileNameCharacter.AtLeastOnce().Select(x => new string(x))
            from _ in Span.EqualTo(@"\\")
            from share in FileNameCharacter.AtLeastOnce().Select(x => new string(x))
            select (IVolume)new NetworkShare(host, share);

        private static TextParser<IVolume> Volume =
            ParseLogicalDisk.Try().Or(ParseNetworkShare);

        private static TextParser<IRelativeFilePath> BareRelativeFilePath =
            from segments in FileName.ManyDelimitedBy(PathSeparator)
            let fileName = string.Join(Path.DirectorySeparatorChar.ToString(), segments)
            select (IRelativeFilePath)new RelativeFilePath(fileName);

        private static TextParser<IRelativeFilePath> RootedRelativeFilePath =
            from _ in PathSeparator
            from path in BareRelativeFilePath.Select(x => x.FullPath)
            let sep = Path.DirectorySeparatorChar.ToString()
            select (IRelativeFilePath)new RelativeFilePath(string.Concat(sep, path));

        private static TextParser<IRelativeFilePath> CurrentRelativePath = 
            from _1 in Character.EqualTo('.').Select(x => x.ToString())
            from _2 in PathSeparator
            from path in BareRelativeFilePath.Select(x => x.FullPath)
            select (IRelativeFilePath)new RelativeFilePath(Path.Combine(".", path));
            
        private static TextParser<IRelativeFilePath> ParentRelativePath =
            from _1 in Span.EqualTo("..")
            from _2 in PathSeparator
            from path in BareRelativeFilePath.Select(x => x.FullPath)
            select (IRelativeFilePath)new RelativeFilePath(Path.Combine("..", path));

        public static TextParser<IRelativeFilePath> RelativeFilePath = 
            RootedRelativeFilePath
                .Or(ParentRelativePath)
                .Or(CurrentRelativePath)
                .Or(BareRelativeFilePath);

        public static TextParser<IRelativeDirectoryPath> RelativeDirectoryPath =
            from path in RelativeFilePath.Select(x => x.FullPath)
            select (IRelativeDirectoryPath)new RelativeDirectoryPath(path);

        public static TextParser<IAbsoluteDirectoryPath> AbsoluteDirectoryPath =
            from volume in Volume
            from _ in PathSeparator
            from path in BareRelativeFilePath.Select(x => x.FullPath)
            let fullPath = $"{volume.Name}{Path.DirectorySeparatorChar}{path}"
            select (IAbsoluteDirectoryPath)new AbsoluteDirectoryPath(volume, fullPath);

        public static TextParser<IAbsoluteFilePath> AbsoluteFilePath =
            from volume in Volume
            from _ in PathSeparator
            from path in BareRelativeFilePath.Select(x => x.FullPath)
            let fullPath = $"{volume.Name}{Path.DirectorySeparatorChar}{path}"
            select (IAbsoluteFilePath)new AbsoluteFilePath(volume, fullPath);
    }
}