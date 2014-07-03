using CodeGeneration.Logic.GenericTemplating;

namespace CodeGeneration.Logic
{
    public interface ICodeGenerator
    {
        string Generate<TMetadata, TTemplate>(TMetadata metadata)
            where TTemplate : ICodeTemplate, new();
    }
}
