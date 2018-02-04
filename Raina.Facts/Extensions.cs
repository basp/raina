namespace Raina.Facts
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;

    public static class Extensions
    {
        public static TypeDefinition GetTypeDefinition(this Type self) =>
            self.GetAssemblyDefinition().Modules
                .SelectMany(x => x.Types)
                .First(x => x.FullName.Equals(self.FullName, StringComparison.OrdinalIgnoreCase));

        // FIXME: This probably won't work well for overloads
        public static MethodDefinition GetMethodDefinition(this Type self, string name) =>
            self.GetAssemblyDefinition().Modules
                .SelectMany(x => x.Types)
                .Where(x => x.FullName.Equals(self.FullName, StringComparison.OrdinalIgnoreCase))
                .SelectMany(x => x.Methods)
                .First(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public static FieldDefinition GetFieldDefinition(this Type self, string name) =>
            self.GetAssemblyDefinition().Modules
                .SelectMany(x => x.Types)
                .Where(x => x.FullName.Equals(self.FullName, StringComparison.OrdinalIgnoreCase))
                .SelectMany(x => x.Fields)
                .First(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public static AssemblyDefinition GetAssemblyDefinition(this Type self)
        {
            var path = self.AssemblyPath();
            var @params = new ReaderParameters
            {
                ReadSymbols = true,
                ReadWrite = false,
            };

            return AssemblyDefinition.ReadAssembly(path, @params);
        }

        private static string AssemblyPath(this Type self)
        {
            var uri = new UriBuilder(self.Assembly.CodeBase);
            return Uri.UnescapeDataString(uri.Path);
        }
    }
}