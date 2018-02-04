namespace Raina.Facts.MethodMetrics
{
    using System;
    using Xunit;

    public class NbOverloadsFacts
    {
        [Fact]
        public void CalculateNbOfOverloads()
        {
            var type = typeof(NbOverloadsFacts);
            var cases = new []
            {
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method1))),
                Tuple.Create(5, type.GetMethodDefinition(nameof(this.Method2))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.NbOverloads()));
        }

        private void Method1() =>
            Console.WriteLine();

        private void Method2() =>
            Console.WriteLine();

        private void Method2(string foo) =>
            Console.WriteLine();

        private void Method2(int foo) =>
            Console.WriteLine();

        private void Method2(int foo, string bar) =>
            Console.WriteLine();

        static void Method2(int u, int v) =>
            Console.WriteLine();
    }
}
