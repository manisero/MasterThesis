using Microsoft.VisualStudio.TextTemplating;

namespace CodeGeneration.Logic
{
    public class CodeGenerationFacade
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IJsonDeserializer _jsonDeserializer;

        public CodeGenerationFacade()
        {
            _fileSystemService = DependencyResolver.Resolve<IFileSystemService>();
            _jsonDeserializer = DependencyResolver.Resolve<IJsonDeserializer>();
        }

        public void GenerateFromFile<TMetadata, TTemplate>(string metadataPath, string destinationPath)
            where TTemplate : new()
        {
            var fileContent = _fileSystemService.GetFileContent(metadataPath);
            var metadata = _jsonDeserializer.Deserialize<TMetadata>(fileContent);

            var template = new TTemplate();

            var templatingSession = new TextTemplatingSession();
            templatingSession["Metadata"] = metadata;

            var templateType = typeof(TTemplate);
            templateType.GetProperty("Session").SetValue(template, templatingSession);
            templateType.GetMethod("Initialize").Invoke(template, new object[0]);
            var result = templateType.GetMethod("TransformText").Invoke(template, new object[0]);
        }
    }
}
