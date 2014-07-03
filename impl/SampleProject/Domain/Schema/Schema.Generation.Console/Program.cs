using CodeGeneration.Logic;
using Schema.Model;
using Schema.Model.Templates;

namespace Schema.Generation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var generationFacade = new CodeGenerationFacade();

            var metadataPath = @"c:\dev\MasterThesis\impl\SampleProject\Domain\Model\Person.json";
            var destinationPath = @"c:\dev\MasterThesis\impl\SampleProject\Sample\Sample.Presentation\Domain\Person.cs";

            generationFacade.GenerateFromFile<Entity, EntityTemplate>(metadataPath, destinationPath);
        }
    }
}
