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

        public void GenerateFromFile<TMetadata>(string metadataPath, string destinationPath)
        {
            var fileContent = _fileSystemService.GetFileContent(metadataPath);
            var metadata = _jsonDeserializer.Deserialize<TMetadata>(fileContent);
        }
    }
}
