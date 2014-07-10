using Ninject;
using Ninject.Extensions.Conventions;

namespace Sample.WebSite.Bootstrap
{
    public class NinjectBootstrapper
    {
        public void Bootstarp(IKernel kernel)
        {
            kernel.Bind(x => x.FromAssembliesMatching("Sample.*")
                              .SelectAllClasses()
                              .NotInNamespaces("Sample.WebSite.Configuration")
                              .BindDefaultInterfaces());
        }
    }
}
