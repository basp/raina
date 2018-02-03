namespace Raina.Facts.MethodMetrics
{
    using System;
    using Xunit;

    public class CCILFacts
    {
        [Fact]
        public void CalculateCCIL()
        {
            var type = typeof(CCILFacts);
            var cases = new[]
            {
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method1))),
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method2))),
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method3))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.CCIL()));
        }

        private void Method1()
        {
        }

        private void Method2()
        {
        }

        private void Method3()
        {
        }
    }
}