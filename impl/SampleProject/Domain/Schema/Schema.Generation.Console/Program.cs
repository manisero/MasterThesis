using CodeGeneration.Logic;
using Schema.Model;

namespace Schema.Generation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var generationFacade = new CodeGenerationFacade();

            generationFacade.GenerateFromFile<Entity>(@"c:\dev\MasterThesis\impl\SampleProject\Domain\Model\Person.json",
                                                      @"c:\dev\MasterThesis\impl\SampleProject\Sample\Sample.Presentation\Domain\Person.cs");
        }
    }
}
