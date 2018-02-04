namespace Raina.Facts.MethodMetrics
{
    using System;
    using Xunit;

    public class NbVariablesFacts
    {
        [Fact]
        public void CalculateNbVariables()
        {
            var type = typeof(NbVariablesFacts);
            var cases = new[]
            {
                Tuple.Create(0, type.GetMethodDefinition(nameof(this.Method1))),
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method2))),
                Tuple.Create(4, type.GetMethodDefinition(nameof(this.Method3))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.NbVariables()));
        }

#pragma warning disable CS0168
        void Method1()
        {
        }

        void Method2()
        {
            int i;
            int j;
        }

        void Method3()
        {
            int i, j;
            byte b;
            float f;
        }
#pragma warning disable CS0168
    }
}
