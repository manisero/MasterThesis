using System;
using System.Collections.Generic;

namespace CodeGeneration.Logic.Generation
{
    public interface ICodeGenerator
    {
        void Generate<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> generationUnits,
                                 Func<object> templateGetter,
                                 string outputDirectoryPath,
                                 params TemplateArgument[] templateArguments);
    }
}
