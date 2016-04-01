using System.IO;
using System.Reflection;

namespace NginxConfigurator.API.Internal
{
    internal static class ResourceHelper
    {
        public static string ReadEmbeddedResource(string name, Assembly assembly)
        {
            name = ProperName(name, assembly);
            using (var stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                {
                    return null;
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static string ProperName(string name, Assembly assembly)
        {
            return assembly.GetName().Name + "." + name.Replace(" ", "_").Replace("\\", ".").Replace("/", ".");
        }
    }
}
