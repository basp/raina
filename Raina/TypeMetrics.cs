namespace Raina
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;

    public static class TypeMetrics
    {
        public static int SizeOfInstance(this TypeDefinition self) =>
            self.HasFields ? self.Fields.Sum(x => x.SizeOfInstance()) : 0;
    }
}
