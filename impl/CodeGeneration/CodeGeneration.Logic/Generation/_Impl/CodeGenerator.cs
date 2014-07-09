using System;
using System.Collections.Generic;
using CodeGeneration.Logic.Infrastructure;

namespace CodeGeneration.Logic.Generation._Impl
{
    public class CodeGenerator : ICodeGenerator
    {
        private readonly ITemplateExecutor _templateExecutor;
        private readonly IFileSystemService _fileSystemService;

        public CodeGenerator(ITemplateExecutor templateExecutor, IFileSystemService fileSystemService)
        {
            _templateExecutor = templateExecutor;
            _fileSystemService = fileSystemService;
        }

        public void Generate<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata,
                                        Func<object> templateGetter,
                                        string destinationDirectoryPath,
                                        params TemplateArgument[] templateArguments)
        {
            foreach (var item in metadata)
            {
                var code = _templateExecutor.Execute(templateGetter(), item.Metadata, templateArguments);
                var destinationFilePath = _fileSystemService.CombinePaths(destinationDirectoryPath, item.OutputFileName);

                _fileSystemService.SetFileContent(destinationFilePath, code);
            }
        }
    }
}
