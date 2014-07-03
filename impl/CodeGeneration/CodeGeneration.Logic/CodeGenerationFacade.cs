namespace CodeGeneration.Logic
{
    public class CodeGenerationFacade
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IJsonDeserializer _jsonDeserializer;
        private readonly ICodeGenerator _codeGenerator;

        public CodeGenerationFacade()
        {
            _fileSystemService = DependencyResolver.Resolve<IFileSystemService>();
            _jsonDeserializer = DependencyResolver.Resolve<IJsonDeserializer>();
            _codeGenerator = DependencyResolver.Resolve<ICodeGenerator>();
        }

        public void GenerateFromFile<TMetadata, TTemplate>(string metadataPath, string destinationPath)
            where TTemplate : new()
        {
            var fileContent = _fileSystemService.GetFileContent(metadataPath);
            var metadata = _jsonDeserializer.Deserialize<TMetadata>(fileContent);
            var code = _codeGenerator.Generate<TMetadata, TTemplate>(metadata);

            _fileSystemService.SetFileContent(destinationPath, code);
        }
    }
}
