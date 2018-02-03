namespace Raina.Facts.MethodMetrics
{
    using System;
    using Xunit;

    public class ILNestingDepthFacts
    {
        [Fact]
        public void CalculateILNestingDepth()
        {
            var type = typeof(ILNestingDepthFacts);
            var cases = new[]
            {
                Tuple.Create(0, type.GetMethodDefinition(nameof(this.Method1))),
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method2))),
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method3))),
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method4))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.ILNestingDepth()));
        }

        private void Method1()
        {
        }

        private void Method2()
        {
            if (DateTime.Now.Ticks > 100)
            {
                Console.WriteLine("bar");
            }
            else
            {
                Console.WriteLine("foo");
            }
        }

        private void Method3()
        {
            var x = 0;

            switch (x)
            {
                case 1: Console.WriteLine("foo"); break;
                case 2: Console.WriteLine("bar"); break;
                case 3: Console.WriteLine("fup"); break;
            }
        }

        private void Method4()
        {
            var x = 0;

            if (x > 0)
            {
                Console.WriteLine("quux");
            }

            if (x < 20)
            {
                Console.WriteLine("frotz");
            }
        }
    }
}