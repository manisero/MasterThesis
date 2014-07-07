using System;

namespace Sample.Manual.Core
{
    public interface IServiceResolver
    {
        object Resolve(Type serviceType);

        TService Resolve<TService>();
    }
}
