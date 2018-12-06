namespace Raina.Path
{
    using System;
    using Superpower;
    using Superpower.Parsers;

    public static class PathParsers
    {
        public static TextParser<char> DriveLetter =
            from letter in Character.Letter
            from _1 in Character.EqualTo(':')
            from _2 in Character.EqualTo('\\')
            select letter;

        public static TextParser<Tuple<string, string>> UNC =
            from _1 in Span.EqualTo(@"\\")
            from server in Character.ExceptIn('\\').Many()
            from _2 in Span.EqualTo('\\')
            from share in Character.ExceptIn('\\').Many()
            select Tuple.Create(new string(server), new string(share));

        public static TextParser<string> DriveLetterPath =
            from drive in DriveLetter
            from directory in Character.AnyChar.Many()
            select new string(directory);
    }
}