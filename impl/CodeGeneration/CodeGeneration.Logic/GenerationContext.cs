namespace CodeGeneration.Logic
{
    public interface IGenerationContext
    {
        string MetadataFileName { get; }
    }

    public class GenerationContext : IGenerationContext
    {
        public string MetadataFileName { get; set; }
    }
}
