using CodeGeneration.Logic.Migrations.ObjectComparison;
using CodeGeneration.Logic.Migrations.ObjectComparison.KeyChangeDetectors;
using Ninject;
using Ninject.Extensions.Conventions;

namespace CodeGeneration.Logic.Bootstrap
{
    public class NinjectBootstrapper
    {
        public void Bootstarp(IKernel kernel)
        {
            kernel.Bind(x => x.FromThisAssembly()
                              .SelectAllClasses()
                              .BindDefaultInterface());

            RegisterCustomBindings(kernel);
        }

        private void RegisterCustomBindings(IKernel kernel)
        {
            kernel.Bind<IKeyChangeDetector>().To<InteractiveKeyChangeDetector>();
        }
    }
}
