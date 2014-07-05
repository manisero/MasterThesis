using System.IO;

namespace CodeGeneration.Logic._Impl
{
    public class GenerationContextFactory : IGenerationContextFactory
    {
        public IGenerationContext Create(string metadataFilePath)
        {
            return new GenerationContext
                {
                    MetadataFileName = Path.GetFileNameWithoutExtension(metadataFilePath)
                };
        }
    }
}
