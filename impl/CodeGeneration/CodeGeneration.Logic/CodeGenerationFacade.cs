using System;
using System.Collections.Generic;
using System.IO;
using CodeGeneration.Logic.Bootstrap;
using CodeGeneration.Logic.DomainProcessing;
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

        public static void GenerateCode<TMetadata>(TMetadata metadata,
                                                   object template,
                                                   string outputFilePath,
                                                   params TemplateArgument[] templateArguments)
        {
            var generationUnit = new CodeGenerationUnit<TMetadata>
                {
                    Metadata = metadata,
                    OutputFileName = Path.GetFileName(outputFilePath)
                };

            GenerateCode(new[] { generationUnit }, () => template, Path.GetDirectoryName(outputFilePath), templateArguments);
        }

        public static void GenerateCode<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> generationUnits,
                                                   Func<object> templateGetter,
                                                   string outputDirectoryPath,
                                                   params TemplateArgument[] templateArguments)
        {
            GetDependencies().CodeGenerator.Generate(generationUnits, templateGetter, outputDirectoryPath, templateArguments);
        }
    }
}
