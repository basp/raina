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
            var cases = new []
            {
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method1)).MethodCa()),
                Tuple.Create(2, type.GetMethodDefinition(nameof(this.Method2)).MethodCa()),
                Tuple.Create(0, type.GetMethodDefinition(nameof(this.Method3)).MethodCa()),
            };
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
}