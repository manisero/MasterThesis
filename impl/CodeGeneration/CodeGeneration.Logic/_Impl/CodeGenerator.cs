using CodeGeneration.Logic.GenericTemplating;
using Microsoft.VisualStudio.TextTemplating;

namespace CodeGeneration.Logic._Impl
{
    public class CodeGenerator : ICodeGenerator
    {
        public string Generate<TMetadata, TTemplate>(TMetadata metadata)
            where TTemplate : ICodeTemplate, new()
        {
            var templateType = typeof(TTemplate);
            var template = new TTemplate();

            var templatingSession = new TextTemplatingSession();
            templatingSession["Metadata"] = metadata;

            templateType.GetProperty("Session").SetValue(template, templatingSession);
            templateType.GetMethod("Initialize").Invoke(template, new object[0]);

            return (string)templateType.GetMethod("TransformText").Invoke(template, new object[0]);
        }
    }
}
