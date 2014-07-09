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
        private readonly ITemplateExecutor _templateExecutor;
        private readonly IDomainDeserializer _domainDeserializer;

        public CodeGenerationFacade(IFileSystemService fileSystemService,
                                    ITemplateExecutor templateExecutor,
                                    IDomainDeserializer domainDeserializer)
        {
            _fileSystemService = fileSystemService;
            _templateExecutor = templateExecutor;
            _domainDeserializer = domainDeserializer;
        }

        public TDomain DeserializeDomain<TDomain>(string rootFolderPath)
            where TDomain : new()
        {
            return _domainDeserializer.Deserialize<TDomain>(rootFolderPath);
        }

        public void GenerateCode<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata, Func<object> templateGetter, string destinationDirectoryPath)
        {
            foreach (var item in metadata)
            {
                var code = _templateExecutor.Execute(templateGetter(), item.Metadata, null);
                var destinationFilePath = _fileSystemService.CombinePaths(destinationDirectoryPath, item.OutputFileName);

                _fileSystemService.SetFileContent(destinationFilePath, code);
            }
        }
    }
}
