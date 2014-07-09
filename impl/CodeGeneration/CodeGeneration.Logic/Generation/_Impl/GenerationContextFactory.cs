namespace CodeGeneration.Logic.Generation._Impl
{
    public class GenerationContextFactory : IGenerationContextFactory
    {
        public IGenerationContext Create()
        {
            return new GenerationContext();
        }

        public IGenerationContext<TCustomContext> Create<TCustomContext>(TCustomContext customContext)
        {
            return new GenerationContext<TCustomContext>
                {
                    Custom = customContext
                };
        }
    }
}
