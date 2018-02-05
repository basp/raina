namespace Raina.Facts
{
    using System;
    using System.Linq;
    using Mono.Cecil;
    using Xunit;

    public class MethodRankFacts
    {
        [Fact]
        public void RanksArePreCalculated()
        {
            var assembly = typeof(MethodRankFacts)
                .GetAssemblyDefinition()
                .WithMethodRanks();

            var nbMethodsInThisAssembly = typeof(MethodRankFacts)
                .GetAssemblyDefinition()
                .Modules
                .SelectMany(x => x.Types)
                .SelectMany(x => x.Methods)
                .Count();

            Assert.Equal(
                nbMethodsInThisAssembly, 
                MethodRankExtensions.Count);
        }
    }
}