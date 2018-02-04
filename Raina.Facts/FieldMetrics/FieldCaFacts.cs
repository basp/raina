namespace Raina.Facts.FieldMetrics
{
    using System;
    using Xunit;

    public class FieldCaFacts
    {
        [Fact]
        public void CalculateFieldCa()
        {
            var type = typeof(FieldCaFacts);
            var cases = new[]
            {
                Tuple.Create(3, type.GetFieldDefinition(nameof(this.a))),
                Tuple.Create(2, type.GetFieldDefinition(nameof(this.b))),
                Tuple.Create(1, type.GetFieldDefinition(nameof(this.c))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.FieldCa()));
        }

        private void Method1()
        {
            Console.WriteLine(this.a);
        }

        private void Method2()
        {
            Console.WriteLine(this.a);
            Console.WriteLine(this.b);
        }

        private void Method3()
        {
            Console.WriteLine(this.a);
            Console.WriteLine(this.b);
            Console.WriteLine(this.c);
        }

#pragma warning disable CS0649
        private readonly string a;
        private readonly string b;
        private readonly string c;
#pragma warning restore CS0649
    }
}