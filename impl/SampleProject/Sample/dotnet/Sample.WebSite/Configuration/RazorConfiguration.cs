using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace Sample.WebSite.Configuration
{
    public class RazorConfiguration : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            return new[]
                {
                    "Sample.Domain"
                };
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            return new string[0];
        }

        public bool AutoIncludeModelNamespace
        {
            get { return true; }
        }
    }
}
