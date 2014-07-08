using CodeGeneration.Logic;
using Schema.Model;
using Schema.Templates;

namespace Schema.Generation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var metadataPath = @"c:\dev\MasterThesis\impl\SampleProject\Domain\Model";
            var destinationPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\Sample.Presentation\Domain\";

            var generationFacade = CodeGenerationFacade.GetInstance();
            var domain = generationFacade.DeserializeDomain<Domain>(metadataPath);

            //generationFacade.GenerateFromDirectory<Entity>(metadataPath, () => new EntityTemplate(), null, "cs");
        }
    }
}
