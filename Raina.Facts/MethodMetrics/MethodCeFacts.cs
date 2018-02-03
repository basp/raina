namespace Raina.Facts.MethodMetrics
{
    using System;
    using Xunit;

    public class MethodCeFacts
    {
        [Fact]
        public void CalculateMethodCe()
        {
            var type = typeof(MethodCeFacts);
            var cases = new []
            {
                Tuple.Create(0, type.GetMethodDefinition(nameof(this.Method1))),
                Tuple.Create(1, type.GetMethodDefinition(nameof(this.Method2))),
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method3))),
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method4))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.MethodCe()));
        }

        private void Method1()
        {
        }

        private void Method2()
        {
            this.Method1();
        }

        private void Method3()
        {
            this.Method2();
            this.Method3();
        }

        private void Method4()
        {
            this.Method3();
            Console.WriteLine("foo");
        }
    }
}