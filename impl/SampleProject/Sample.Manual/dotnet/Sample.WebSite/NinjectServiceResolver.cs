using System;
using Ninject;
using Sample.Core;

namespace Sample.WebSite
{
    public class NinjectServiceResolver : IServiceResolver
    {
        private readonly IKernel _kernel;

        public NinjectServiceResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object Resolve(Type serviceType)
        {
            return _kernel.Get(serviceType);
        }

        public TService Resolve<TService>()
        {
            return _kernel.Get<TService>();
        }
    }
}
