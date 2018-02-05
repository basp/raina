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
        public static int DIT(this TypeDefinition self) =>
            self.BaseType != null ? 1 + self.BaseType.Resolve().DIT() : 0;

        public static int SizeOfInstance(this TypeDefinition self) =>
            self.HasFields
                ? self.Fields.Sum(x => x.SizeOfInstance()) + self.BaseType.SizeOfInstance()
                : 0;

        public static bool DependsOn(this TypeDefinition self, TypeDefinition other) => false;

        private static int SizeOfInstance(this TypeReference self) =>
            self.Resolve().SizeOfInstance();
    }
}
