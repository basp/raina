namespace Raina
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;
    using Mono.Cecil;

    public static class MethodRankExtensions
    {
        public static AssemblyDefinition WithMethodRanks(this AssemblyDefinition self)
        {
            CalculateMethodRanks(self);
            return self;
        }

        public static double Rank(this MethodDefinition self) =>
            R.GetOrAdd(self.FullName, -1);

        public static int Count => R.Count;

        private const double d = 0.85;

        private static ConcurrentDictionary<string, double> R =
            new ConcurrentDictionary<string, double>();

        private static void CalculateMethodRanks(AssemblyDefinition assembly, int iter = 20)
        {
            var methods = assembly.Modules
                .SelectMany(x => x.Types)
                .SelectMany(x => x.Methods);

            var callers = methods
                .ToDictionary(x => x.FullName, x => x.Callers());

            var nbcallees = methods
                .ToDictionary(x => x.FullName, x => x.Callees().Count());

            R = new ConcurrentDictionary<string, double>(
                methods.ToDictionary(x => x.FullName, x => 1.0));

            // In order for the algorithm to come up with a good result
            // we need to run it a few times re-using its previous results
            // as our new input.
            for (var i = 0; i < iter; i++)
            {
                foreach (var m in methods)
                {
                    // This is basically a straight translation of
                    // Google's PageRank idea.
                    R[m.FullName] = (1.0 - d) + d * callers[m.FullName]
                        .Select(x => R[x] / nbcallees[x])
                        .Sum();
                }
            }
        }

        private static IEnumerable<string> Callees(this MethodDefinition self) =>
            self.Module.Assembly.Modules
                .Where(x => self.HasBody)
                .SelectMany(x => x.Types)
                .SelectMany(x => x.Methods)
                .Where(x => self.DependsOn(x))
                .Select(x => x.FullName);

        private static IEnumerable<string> Callers(this MethodDefinition self) =>
            self.Module.Assembly.Modules
                .SelectMany(x => x.Types)
                .SelectMany(x => x.Methods)
                .Where(x => x.HasBody)
                .Where(x => x.DependsOn(self))
                .Select(x => x.FullName);
    }
}
