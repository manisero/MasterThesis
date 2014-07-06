using Nancy.Bootstrappers.Ninject;
using Ninject;

namespace Sample.Manual.WebSite.Bootstrap
{
    public class NancyBootstrapper : NinjectNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IKernel existingContainer)
        {
            new NinjectBootstrapper().Bootstarp(existingContainer);
        }
    }
}
