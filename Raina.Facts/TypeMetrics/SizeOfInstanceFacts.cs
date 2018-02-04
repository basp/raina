namespace Raina.Facts.TypeMetrics
{
    using System;
    using Xunit;

    public class SizeOfInstanceFacts
    {
        [Fact]
        public void CalculateSizeOfInstance()
        {
            var cases = new[]
            {
                Tuple.Create(Frotz.ExpectedSizeOfInstance, typeof(Frotz).GetTypeDefinition()),
                Tuple.Create(Quux.ExpectedSizeOfInstance, typeof(Quux).GetTypeDefinition()),
                Tuple.Create(Bar.ExpectedSizeOfInstance, typeof(Bar).GetTypeDefinition()),
                Tuple.Create(Foo.ExpectedSizeOfInstance, typeof(Foo).GetTypeDefinition()),
                Tuple.Create(Zoz.ExpectedSizeOfInstance, typeof(Zoz).GetTypeDefinition()),
            };

            Array.ForEach(cases, x => Assert.Equal(x.Item1, x.Item2.SizeOfInstance()));
        }
    }

#pragma warning disable CS0169
    class Zoz : Foo
    {
        new internal static int ExpectedSizeOfInstance =>
            0                               // static
            + sizeof(int)                   // u
            + 4                             // f
            + Foo.ExpectedSizeOfInstance;   // base

        static int v;

        int u;

        Foo f;
    }

    class Foo
    {
        internal static int ExpectedSizeOfInstance =>
            4                               // reference
            + Frotz.ExpectedSizeOfInstance; // value type

        Bar b;

        Frotz f;
    }

    class Bar
    {
        internal static int ExpectedSizeOfInstance =>
            0                               // static
            + sizeof(int)                   // i
            + 4;                            // reference

        static int si;

        int i;

        string s;
    }

    struct Quux
    {
        internal static int ExpectedSizeOfInstance =>
            sizeof(short)                   // s
            + Frotz.ExpectedSizeOfInstance; // value type

        short s;

        Frotz f;
    }

    struct Frotz
    {
        internal static int ExpectedSizeOfInstance =>
            sizeof(int)                     // i
            + sizeof(byte);                 // b

        int i;

        byte b;
    }
#pragma warning restore CS0169
}
