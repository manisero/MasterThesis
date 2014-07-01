using CodeGeneration.Presentation.Bootstrap.Modules;
using Ninject;

namespace CodeGeneration.Presentation.Bootstrap
{
    public class NinjectBootstrapper
    {
        public void RegisterModules(IKernel kernel)
        {
            kernel.Load(new LogicModule());
        }
    }
}
