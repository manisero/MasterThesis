using System.Collections.Generic;
using CodeGeneration.Logic;
using Schema.Model;
using System.Linq;

namespace Schema.Generation.Console
{
    public static class DomainItemsCollectionExtensions
    {
        public static View GetView(this IDictionary<string, View> views, string viewName)
        {
            View view;

            if (views.TryGetValue(viewName, out view))
            {
                return view;
            }

            view = new View
                {
                    Name = viewName,
                    Fields = new List<ViewField>()
                };

            views.Add(viewName, view);

            return view;
        }

        public static IEnumerable<CodeGenerationUnit<TMetadata>> ToCodeGenerationUnits<TMetadata>(this IEnumerable<TMetadata> metadata,
                                                                                                  string outputFileExtension,
                                                                                                  string outputFileNamePrefix = null,
                                                                                                  string outputFileNameSuffix = null)
            where TMetadata : INamed
        {
            return metadata.Select(x => new CodeGenerationUnit<TMetadata>
                {
                    Metadata = x,
                    OutputFileName = string.Format("{0}{1}{2}.{3}", outputFileNamePrefix, x.Name, outputFileNameSuffix, outputFileExtension)
                });
        }
    }
}
