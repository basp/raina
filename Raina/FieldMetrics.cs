namespace Raina
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;

    public static class FieldMetrics
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
            if (self.IsStatic)
            {
                return 0;
            }

            var typeName = self.FieldType.FullName;
            if (PredefinedSizes.ContainsKey(typeName))
            {
                return PredefinedSizes[typeName];
            }

            if (self.FieldType.IsValueType)
            {
                return self.FieldType.Resolve().SizeOfInstance();
            }

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