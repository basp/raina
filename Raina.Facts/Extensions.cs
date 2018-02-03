namespace Raina.Facts
{
    using System;
    using System.Reflection;
    using System.Linq;
    using Mono.Cecil;

    public static class Extensions
    {
        internal static MethodDefinition GetMethodDefinition(this Type self, string name) =>
            self.GetAssemblyDefinition().Modules
                .SelectMany(x => x.Types)
                .Where(x => x.FullName.Equals(self.FullName, StringComparison.OrdinalIgnoreCase))
                .SelectMany(x => x.Methods)
                .First(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        internal static FieldDefinition GetFieldDefinition(this Type self, string name) =>
            self.GetAssemblyDefinition().Modules
                .SelectMany(x => x.Types)
                .Where(x => x.FullName.Equals(self.FullName, StringComparison.OrdinalIgnoreCase))
                .SelectMany(x => x.Fields)
                .First(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        private static AssemblyDefinition GetAssemblyDefinition(this Type self)
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