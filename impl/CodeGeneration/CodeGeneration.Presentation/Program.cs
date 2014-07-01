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

            kernel.Get<ICodeGenerationFacade>().GenerateFromFile(null);
        }
    }
}
