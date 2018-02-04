namespace Raina.Facts.MethodMetrics
{
    using System;
    using Xunit;

    public class NbParametersFacts
    {
        [Fact]
        public void CalculateNbParameters()
        {
            var type = typeof(NbParametersFacts);
            var cases = new[]
            {
                Tuple.Create(0, type.GetMethodDefinition(nameof(this.Method1))),
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method2))),
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method3))),
                Tuple.Create(1, typeof(Foo).GetMethodDefinition(nameof(Foo.Method4))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.NbParameters()));
        }

        void Method1()
        {
        }

        void Method2(string s)
        {
        }

        void Method3(int i, byte b)
        {
        }
    }

    static class Foo
    {
        public static void Method4(this NbParametersFacts self)
        {
        }
    }
}
