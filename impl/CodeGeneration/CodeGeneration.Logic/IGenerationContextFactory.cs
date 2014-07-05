namespace CodeGeneration.Logic
{
    public interface IGenerationContextFactory
    {
        IGenerationContext Create(string metadataFilePath);
    }
}
