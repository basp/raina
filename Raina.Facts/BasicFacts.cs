namespace Raina.Facts
{
    using System;
    using Xunit;

    public class BasicFacts
    {
        static void Method1()
        {
        }

        static void Method2()
        {
        }

        static void Method3() { }

        [Fact]
        public void CalculateOffsets()
        {
            var type = typeof(BasicFacts);
            var cases = new[]
            {
                Tuple.Create(9, 9, type.GetMethodDefinition(nameof(this.Method1))),
                Tuple.Create(13, 9, type.GetMethodDefinition(nameof(this.Method2))),
                Tuple.Create(16, 31, type.GetMethodDefinition(nameof(this.Method3))),
            };

            Array.ForEach(cases, x => {
                var offset = x.Item3.GetOffset();
                Assert.Equal(x.Item1, offset.Item1);
                Assert.Equal(x.Item2, offset.Item2);
            });
        }
    }
}