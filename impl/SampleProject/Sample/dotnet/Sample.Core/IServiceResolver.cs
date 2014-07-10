using System;

namespace Sample.Core
{
    public interface IServiceResolver
    {
        object Resolve(Type serviceType);

        TService Resolve<TService>();
    }
}
