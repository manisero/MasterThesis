namespace CodeGeneration.Logic.Generation
{
    public interface ICodeGenerator
    {
        string Generate<TMetadata>(TMetadata metadata, object template, IGenerationContext context);
    }
}
