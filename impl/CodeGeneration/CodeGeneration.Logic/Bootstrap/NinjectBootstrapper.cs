using CodeGeneration.Logic.Bootstrap.Modules;
using Ninject;

namespace CodeGeneration.Logic.Bootstrap
{
    public class NinjectBootstrapper
    {
        public void RegisterModules(IKernel kernel)
        {
            kernel.Load(new LogicModule());
        }
    }
}
