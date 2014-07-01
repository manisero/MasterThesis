using CodeGeneration.Logic;
using CodeGeneration.Presentation.Bootstrap;
using Ninject;

namespace CodeGeneration.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            new NinjectBootstrapper().RegisterModules(kernel);

            var codeGenerationFacade = kernel.Get<ICodeGenerationFacade>();
            codeGenerationFacade.GenerateFromFile(@"c:\dev\MasterThesis\impl\SampleProject\Domain\Model\Person.json");
        }
    }
}
