namespace CodeGeneration.Logic.Generation
{
    public interface IGenerationContextFactory
    {
        IGenerationContext Create();

        IGenerationContext<TCustomContext> Create<TCustomContext>(TCustomContext customContext);
    }
}
