using CodeGeneration.Logic.Bootstrap;
using Ninject;

namespace CodeGeneration.Logic
{
    public class CodeGenerationFacade
    {
        private static CodeGenerationFacade _instance;

        public static CodeGenerationFacade GetInstance()
        {
            if (_instance == null)
            {
                var kernel = new StandardKernel();
                new NinjectBootstrapper().Bootstarp(kernel);

                _instance = kernel.Get<CodeGenerationFacade>();
            }

            return _instance;
        }

        private readonly IFileSystemService _fileSystemService;
        private readonly IJsonDeserializer _jsonDeserializer;
        private readonly ICodeGenerator _codeGenerator;

        public CodeGenerationFacade(IFileSystemService fileSystemService,
                                    IJsonDeserializer jsonDeserializer,
                                    ICodeGenerator codeGenerator)
        {
            _fileSystemService = fileSystemService;
            _jsonDeserializer = jsonDeserializer;
            _codeGenerator = codeGenerator;
        }

        public void GenerateFromFile<TMetadata>(string metadataPath, object template, string destinationPath)
        {
            var fileContent = _fileSystemService.GetFileContent(metadataPath);
            var metadata = _jsonDeserializer.Deserialize<TMetadata>(fileContent);
            var code = _codeGenerator.Generate(metadata, template);

            _fileSystemService.SetFileContent(destinationPath, code);
        }
    }
}
