using System;
using System.IO;
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

        public void GenerateFromFile<TMetadata>(string metadataFilePath, object template, string destinationFilePath)
        {
            var metadataFileContent = _fileSystemService.GetFileContent(metadataFilePath);
            var metadata = _jsonDeserializer.Deserialize<TMetadata>(metadataFileContent);
            var code = _codeGenerator.Generate(metadata, template);

            _fileSystemService.SetFileContent(destinationFilePath, code);
        }

        public void GenerateFromDirectory<TMetadata>(string metadataDirectoryPath, Func<object> templateGetter, string destinationDirectoryPath, string destinationFileExtension)
        {
            var metadataPaths = _fileSystemService.GetFilesInDirectory(metadataDirectoryPath);

            foreach (var metadataPath in metadataPaths)
            {
                var relativePath = _fileSystemService.GetRelativePath(metadataDirectoryPath, metadataPath);
                var relativeDestinationPath = _fileSystemService.ChangeFileExtension(relativePath, destinationFileExtension);
                var destinationPath = _fileSystemService.CombinePaths(destinationDirectoryPath, relativeDestinationPath);

                GenerateFromFile<TMetadata>(metadataPath, templateGetter(), destinationPath);
            }
        }
    }
}
