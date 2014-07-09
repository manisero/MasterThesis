using System;
using System.Collections.Generic;
using CodeGeneration.Logic.Infrastructure;

namespace CodeGeneration.Logic.Generation._Impl
{
    public class CodeGenerator : ICodeGenerator
    {
        private readonly IGenerationContextFactory _contextFactory;
        private readonly ITemplateExecutor _templateExecutor;
        private readonly IFileSystemService _fileSystemService;

        public CodeGenerator(IGenerationContextFactory contextFactory, ITemplateExecutor templateExecutor, IFileSystemService fileSystemService)
        {
            _contextFactory = contextFactory;
            _templateExecutor = templateExecutor;
            _fileSystemService = fileSystemService;
        }

        public void Generate<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata, Func<object> templateGetter, string destinationDirectoryPath)
        {
            GenerateCode(metadata, _contextFactory.Create(), templateGetter, destinationDirectoryPath);
        }

        public void Generate<TMetadata, TContext>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata, Func<object> templateGetter, string destinationDirectoryPath, TContext context)
        {
            GenerateCode(metadata, _contextFactory.Create(context), templateGetter, destinationDirectoryPath);
        }

        private void GenerateCode<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata, IGenerationContext context, Func<object> templateGetter, string destinationDirectoryPath)
        {
            foreach (var item in metadata)
            {
                var code = _templateExecutor.Execute(templateGetter(), item.Metadata, context);
                var destinationFilePath = _fileSystemService.CombinePaths(destinationDirectoryPath, item.OutputFileName);

                _fileSystemService.SetFileContent(destinationFilePath, code);
            }
        }
    }
}
