namespace CodeGeneration.Logic
{
    public class CodeGenerationFacade : ICodeGenerationFacade
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IJsonDeserializer _jsonDeserializer;

        public CodeGenerationFacade()
        {
            _fileSystemService = DependencyResolver.Resolve<IFileSystemService>();
            _jsonDeserializer = DependencyResolver.Resolve<IJsonDeserializer>();
        }

        public void GenerateFromFile(string filePath)
        {
            var fileContent = _fileSystemService.GetFileContent(filePath);
            var metadata = _jsonDeserializer.Deserialize<dynamic>(fileContent);
        }
    }
}
