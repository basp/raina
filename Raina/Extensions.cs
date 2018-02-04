namespace Raina
{
    using System;
    using System.Linq;
    using Mono.Cecil;

    public static class Extensions
    {
        const int Junk = 16707566;

        public static string Document(this MethodDefinition self) =>
            self.DebugInformation.SequencePoints.First().Document.Url;

        // Returns a (line,column) tuple pointing to where the method
        // body starts (in terms of offsets from the document origin).
        public static Tuple<int,int> GetOffset(this MethodDefinition self)
        {
            var point = self.DebugInformation
                .SequencePoints
                .First(x => x.StartLine < Junk);

            return Tuple.Create(point.StartLine, point.StartColumn);
        }
    }
}