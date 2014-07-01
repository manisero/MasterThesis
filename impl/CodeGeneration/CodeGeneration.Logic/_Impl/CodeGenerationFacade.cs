namespace CodeGeneration.Logic._Impl
{
    public class CodeGenerationFacade : ICodeGenerationFacade
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IJsonDeserializer _jsonDeserializer;

        public CodeGenerationFacade(IFileSystemService fileSystemService, IJsonDeserializer jsonDeserializer)
        {
            _fileSystemService = fileSystemService;
            _jsonDeserializer = jsonDeserializer;
        }

        public void GenerateFromFile(string filePath)
        {
            var fileContent = _fileSystemService.GetFileContent(filePath);
            var metadata = _jsonDeserializer.Deserialize<dynamic>(fileContent);
        }
    }
}
