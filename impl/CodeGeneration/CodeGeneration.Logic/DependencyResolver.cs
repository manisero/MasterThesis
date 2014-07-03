using CodeGeneration.Logic.Bootstrap;
using Ninject;

namespace CodeGeneration.Logic
{
    public static class DependencyResolver
    {
        private static IKernel _kernel;

        public static TDependency Resolve<TDependency>()
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel();
                new NinjectBootstrapper().RegisterModules(_kernel);
            }

            return _kernel.Get<TDependency>();
        }
    }
}
