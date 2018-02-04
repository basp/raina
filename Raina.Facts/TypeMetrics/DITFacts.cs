namespace Raina.Facts
{
    using System;
    using Xunit;

    public class DITFacts
    {
        [Fact]
        public void CalculateDIT()
        {
            var cases = new []
            {
                Tuple.Create(1, typeof(Foo).GetTypeDefinition()),
                Tuple.Create(2, typeof(Bar).GetTypeDefinition()),
                Tuple.Create(3, typeof(Quux).GetTypeDefinition()),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.DIT()));
        }
    }

    class Foo
    {
    }

    class Bar : Foo
    {
    }

    class Quux : Bar 
    {
    }
}