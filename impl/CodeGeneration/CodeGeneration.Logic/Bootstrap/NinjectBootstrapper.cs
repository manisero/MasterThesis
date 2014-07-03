using Ninject;
using Ninject.Extensions.Conventions;

namespace CodeGeneration.Logic.Bootstrap
{
    public class NinjectBootstrapper
    {
        public void RegisterModules(IKernel kernel)
        {
            kernel.Bind(x => x.FromThisAssembly()
                              .SelectAllClasses()
                              .BindDefaultInterface());
        }
    }
}
