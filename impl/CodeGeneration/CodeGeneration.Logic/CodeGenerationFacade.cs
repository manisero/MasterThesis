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
        private static Facade _instance;

        private static Facade GetInstance()
        {
            if (_instance == null)
            {
                var kernel = new StandardKernel();
                new NinjectBootstrapper().Bootstarp(kernel);

                _instance = kernel.Get<Facade>();
            }

            return _instance;
        }

        public static TDomain DeserializeDomain<TDomain>(string rootFolderPath)
            where TDomain : new()
        {
            return GetInstance().DeserializeDomain<TDomain>(rootFolderPath);
        }

        public static void GenerateCode<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata, Func<object> templateGetter, string destinationDirectoryPath)
        {
            GetInstance().GenerateCode(metadata, templateGetter, destinationDirectoryPath);
        }
    }

    internal class Facade
    {
        private readonly IDomainDeserializer _domainDeserializer;
        private readonly ICodeGenerator _codeGenerator;

        public Facade(IDomainDeserializer domainDeserializer, ICodeGenerator codeGenerator)
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
