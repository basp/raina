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
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method2))),
                Tuple.Create(3, type.GetMethodDefinition(nameof(this.Method3))),
                Tuple.Create(5, type.GetMethodDefinition(nameof(this.Method4))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.CCIL()));
        }

        private void Method1()
        {
        }

        private void Method2()
        {
            var x = 0;

            if (x > 100)
            {
                Console.WriteLine("foo");
            }
        }

        private void Method3()
        {
            var x = 0;

            if (x > 100)
            {
                Console.WriteLine("foo");
            }
            else
            {
                Console.WriteLine("bar");
            }
        }

        private void Method4()
        {
            var x = 0;
            var y = 0;

            if (x > 100)
            {
                Console.WriteLine("foo");
            }
            else
            {
                Console.WriteLine("bar");

                if (y < 100)
                {
                    Console.WriteLine("quux");
                }
                else
                {
                    Console.WriteLine("frotz");
                }
            }
        }
    }
}