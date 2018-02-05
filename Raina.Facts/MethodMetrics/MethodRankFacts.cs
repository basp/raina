namespace Raina.Facts
{
    using System;
    using System.Linq;
    using Mono.Cecil;
    using Xunit;

    public class MethodRankFacts
    {
        private AssemblyDefinition assembly;

        public MethodRankFacts()
        {

            assembly = typeof(MethodRankFacts)
                .GetAssemblyDefinition()
                .WithMethodRanks();
        }

        [Fact]
        public void RanksArePreCalculated()
        {
            var nbMethodsInThisAssembly = typeof(MethodRankFacts)
                .GetAssemblyDefinition()
                .Modules
                .SelectMany(x => x.Types)
                .SelectMany(x => x.Methods)
                .Count();

            Assert.Equal(
                nbMethodsInThisAssembly, 
                MethodRankExtensions.GetRankings().Count());
        }

        [Fact]
        public void VerifyMethodRanks()
        {
        }
    }
}