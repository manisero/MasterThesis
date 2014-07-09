using System;
using System.Collections.Generic;
using CodeGeneration.Logic.Bootstrap;
using CodeGeneration.Logic.DomainDeserialization;
using CodeGeneration.Logic.Generation;
using CodeGeneration.Logic.Infrastructure;
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
        private readonly IGenerationContextFactory _contextFactory;
        private readonly ICodeGenerator _codeGenerator;
        private readonly IDomainDeserializer _domainDeserializer;

        public CodeGenerationFacade(IFileSystemService fileSystemService,
                                    IJsonDeserializer jsonDeserializer,
                                    IGenerationContextFactory contextFactory,
                                    ICodeGenerator codeGenerator,
                                    IDomainDeserializer domainDeserializer)
        {
            _fileSystemService = fileSystemService;
            _jsonDeserializer = jsonDeserializer;
            _contextFactory = contextFactory;
            _codeGenerator = codeGenerator;
            _domainDeserializer = domainDeserializer;
        }

        public void GenerateFromMetadata<TMetadata>(TMetadata metadata, object template, string destinationFilePath)
        {
            var code = _codeGenerator.Generate(metadata, template, null);

            if (destinationFilePath != null)
            {
                _fileSystemService.SetFileContent(destinationFilePath, code);
            }
        }

        public void GenerateFromMetadata<TMetadata>(IDictionary<TMetadata, string> metadata, Func<object> templateGetter, string destinationDirectoryPath)
        {
            foreach (var item in metadata)
            {
                var destinationPath = _fileSystemService.CombinePaths(destinationDirectoryPath, item.Value);

                GenerateFromMetadata(item.Key, templateGetter(), destinationPath);
            }
        }

        public void GenerateFromFile<TMetadata>(string metadataFilePath, object template, string destinationFilePath)
        {
            var metadataFileContent = _fileSystemService.GetFileContent(metadataFilePath);
            var metadata = _jsonDeserializer.Deserialize<TMetadata>(metadataFileContent);
            var context = _contextFactory.Create(metadataFilePath);

            var code = _codeGenerator.Generate(metadata, template, context);

            if (destinationFilePath != null)
            {
                _fileSystemService.SetFileContent(destinationFilePath, code);
            }
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

        public TDomain DeserializeDomain<TDomain>(string rootFolderPath)
            where TDomain : new()
        {
            return _domainDeserializer.Deserialize<TDomain>(rootFolderPath);
        }
    }
}
