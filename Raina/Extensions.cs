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

        public static Tuple<int,int> GetStartOffset(this MethodDefinition self)
        {
            var point = self.DebugInformation
                .SequencePoints
                .First(x => x.StartLine < Junk);

            // The line we get back points to where the actual body starts
            // but you kinda expect to end up at the method declaration.
            //
            // NOTE: this is very hacky, we'll have to see how well this 
            // works in practice.
            const int fudge = 1;

            return Tuple.Create(point.StartLine - fudge, point.StartColumn);
        }
    }
}