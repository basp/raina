namespace Raina.Facts.MethodMetrics
{
    using System;
    using Xunit;

    public class NbLinesOfCodeFacts
    {
        [Fact]
        public void CalculateNbLinesOfCode()
        {
            var type = typeof(NbLinesOfCodeFacts);
            var cases = new[]
            {
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method1))),
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method2))),
                Tuple.Create(4, type.GetMethodDefinition(nameof(this.Method3))),
                Tuple.Create(3, type.GetMethodDefinition(nameof(this.Method4))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.NbLinesOfCode()));
        }

        private void Method1() => Console.WriteLine("foo");

        private void Method2()
        {
            Console.WriteLine("foo");
            Console.WriteLine("bar");
        }

        private void Method3()
        {
            Console.WriteLine("foo");
            Console.WriteLine("bar");

            if (DateTime.Now.Ticks > 100)
            {
                Console.WriteLine("quux");
            }
        }

        private void Method4()
        {
            if (DateTime.Now.Ticks > 100)
            {
                Console.WriteLine("quux");
            }
            else
            {
                Console.WriteLine("fooz");
            }
        }
    }
}
