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

        public void Generate<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> generationUnits,
                                        Func<object> templateGetter,
                                        string outputDirectoryPath,
                                        params TemplateArgument[] templateArguments)
        {
            foreach (var unit in generationUnits)
            {
                var code = _templateExecutor.Execute(templateGetter(), unit.Metadata, templateArguments);
                var outputFilePath = _fileSystemService.CombinePaths(outputDirectoryPath, unit.OutputFileName);

                _fileSystemService.SetFileContent(outputFilePath, code);
            }
        }
    }
}
