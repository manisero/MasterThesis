using Ninject;
using Ninject.Extensions.Conventions;

namespace Sample.Manual.WebSite.Bootstrap
{
    public class NinjectBootstrapper
    {
        public void Bootstarp(IKernel kernel)
        {
            kernel.Bind(x => x.FromAssembliesMatching("Sample.Manual.*")
                              .SelectAllClasses()
                              .NotInNamespaces("Sample.Manual.WebSite.Configuration")
                              .BindDefaultInterface());
        }
    }
}
