namespace Raina.Facts.FieldMetrics
{
    using System;
    using Xunit;

    public class SizeOfInstanceFacts
    {
        [Fact]
        public void CalculateSizeOfInstance()
        {
            var type = typeof(SizeOfInstanceFacts);
            var cases = new[]
            {
                Tuple.Create(0, type.GetFieldDefinition(nameof(si))),
                Tuple.Create(4, type.GetFieldDefinition(nameof(this.s))),
                Tuple.Create(4, type.GetFieldDefinition(nameof(this.i))),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.SizeOfInstance()));
        }

#pragma warning disable CS0649
        static int si;
        string s;
        int i;
#pragma warning restore CS0649        
    }
}
