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
        #region Dependencies resolution

        private class Dependencies
        {
            public IDomainDeserializer DomainDeserializer { get; private set; }
            public ICodeGenerator CodeGenerator { get; private set; }

            public Dependencies(IDomainDeserializer domainDeserializer, ICodeGenerator codeGenerator)
            {
                DomainDeserializer = domainDeserializer;
                CodeGenerator = codeGenerator;
            }
        }

        private static Dependencies _dependencies;
        private static Dependencies GetDependencies()
        {
            if (_dependencies == null)
            {
                var kernel = new StandardKernel();
                new NinjectBootstrapper().Bootstarp(kernel);

                _dependencies = kernel.Get<Dependencies>();
            }

            return _dependencies;
        }

        #endregion

        public static TDomain DeserializeDomain<TDomain>(string rootFolderPath)
            where TDomain : new()
        {
            return GetDependencies().DomainDeserializer.Deserialize<TDomain>(rootFolderPath);
        }

        public static void GenerateCode<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata,
                                                   Func<object> templateGetter,
                                                   string destinationDirectoryPath,
                                                   params TemplateArgument[] templateArguments)
        {
            GetDependencies().CodeGenerator.Generate(metadata, templateGetter, destinationDirectoryPath, templateArguments);
        }
    }
}
