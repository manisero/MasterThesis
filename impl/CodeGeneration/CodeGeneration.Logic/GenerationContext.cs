namespace CodeGeneration.Logic
{
    public interface IGenerationContext
    {
    }

    public interface IGenerationContext<TCustomContext> : IGenerationContext
    {
        TCustomContext Custom { get; }
    }

    public class GenerationContext : IGenerationContext
    {
    }

    public class GenerationContext<TCustomContext> : GenerationContext, IGenerationContext<TCustomContext>
    {
        public TCustomContext Custom { get; set; }
    }
}
