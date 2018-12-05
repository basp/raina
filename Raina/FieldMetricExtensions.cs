namespace Raina
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;

    public static class FieldMetricExtensions
    {
        public static int FieldCa(this FieldDefinition field) =>
            field.Module.Assembly.Modules
                .SelectMany(x => x.Types)
                .SelectMany(x => x.Methods)
                .Where(x => x.HasBody)
                .Where(x => x.DependsOn(field))
                .Count();

        public static int SizeOfInstance(this FieldDefinition self)
        {
            // If a field is static then its instance size
            // is zero by definition.
            if (self.IsStatic)
            {
                return 0;
            }

            // Eventually everything boils down to these
            // predefined sizes.
            var typeName = self.FieldType.FullName;
            if (PredefinedSizes.ContainsKey(typeName))
            {
                return PredefinedSizes[typeName];
            }

            // For structs we'll return *its* size (i.e. the sum
            // of its field sizes).
            if (self.FieldType.IsValueType)
            {
                return self.FieldType.Resolve().SizeOfInstance();
            }

            // For reference types we'll just return the default
            // int size (i.e. the size of the underlying pointer
            // into the heap).
            return sizeof(int);
        }

        private static bool DependsOn(this MethodDefinition self, FieldDefinition field) =>
            self.Body.Instructions.Any(x => field.Equals(x.Operand));

        private static readonly IDictionary<string, int> PredefinedSizes =
            new Dictionary<string, int>
            {
                [typeof(bool).FullName] = sizeof(bool),
                [typeof(byte).FullName] = sizeof(byte),
                [typeof(char).FullName] = sizeof(char),
                [typeof(decimal).FullName] = sizeof(decimal),
                [typeof(double).FullName] = sizeof(double),
                [typeof(float).FullName] = sizeof(float),
                [typeof(int).FullName] = sizeof(int),
                [typeof(long).FullName] = sizeof(long),
                [typeof(sbyte).FullName] = sizeof(sbyte),
                [typeof(short).FullName] = sizeof(short),
                [typeof(uint).FullName] = sizeof(uint),
                [typeof(ulong).FullName] = sizeof(ulong),
                [typeof(ushort).FullName] = sizeof(ushort),
            };
    }
}
