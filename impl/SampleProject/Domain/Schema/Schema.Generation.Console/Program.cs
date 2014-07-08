using CodeGeneration.Logic;
using Schema.Model;using Schema.Templates;

namespace Schema.Generation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var metadataPath = @"c:\dev\MasterThesis\impl\SampleProject\Domain\Model";
            var destinationPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\Sample.Presentation\Domain\";

            var generationFacade = CodeGenerationFacade.GetInstance();
            generationFacade.GenerateFromDirectory<Entity>(metadataPath, () => new EntityTemplate(), destinationPath, "cs");
        }
    }
}
