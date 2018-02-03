namespace Raina.Facts.MethodMetrics
{
    using System;
    using Xunit;

    public class MethodCaFacts
    {
        [Fact]
        public void CalculateMethodCa()
        {
            var type = typeof(MethodCaFacts);
            var cases = new[]
            {
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method1))),
                Tuple.Create(3, type.GetMethodDefinition(nameof(this.Method2))),
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method3))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.MethodCa()));
        }

        private void Method1()
        {
            this.Method2();
            Console.WriteLine("foo");
        }

        private void Method2()
        {
            this.Method1();
            this.Method2();
        }

        private void Method3()
        {
            this.Method1();
            this.Method2();
            this.Method3();
        }
    }
=====
}