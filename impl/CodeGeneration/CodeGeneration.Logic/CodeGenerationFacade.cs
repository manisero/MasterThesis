using System;
using System.Collections.Generic;
using CodeGeneration.Logic.Bootstrap;
using CodeGeneration.Logic.DomainDeserialization;
using CodeGeneration.Logic.Generation;
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

        private readonly IDomainDeserializer _domainDeserializer;
        private readonly ICodeGenerator _codeGenerator;

        public CodeGenerationFacade(IDomainDeserializer domainDeserializer, ICodeGenerator codeGenerator)
        {
            _domainDeserializer = domainDeserializer;
            _codeGenerator = codeGenerator;
        }

        public TDomain DeserializeDomain<TDomain>(string rootFolderPath)
            where TDomain : new()
        {
            return _domainDeserializer.Deserialize<TDomain>(rootFolderPath);
        }

        public void GenerateCode<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata, Func<object> templateGetter, string destinationDirectoryPath)
        {
            _codeGenerator.Generate(metadata, templateGetter, destinationDirectoryPath);
        }
    }
}
