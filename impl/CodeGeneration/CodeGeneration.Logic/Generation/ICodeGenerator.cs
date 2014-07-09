using System;
using System.Collections.Generic;

namespace CodeGeneration.Logic.Generation
{
    public interface ICodeGenerator
    {
        void Generate<TMetadata>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata, Func<object> templateGetter, string destinationDirectoryPath);

        void Generate<TMetadata, TContext>(IEnumerable<CodeGenerationUnit<TMetadata>> metadata, Func<object> templateGetter, string destinationDirectoryPath, TContext context);
    }
}
