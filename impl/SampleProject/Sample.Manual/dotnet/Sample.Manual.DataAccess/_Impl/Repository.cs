using System.Collections.Generic;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.DataAccess._Impl
{
    public class Repository<TView> : IRepository<TView>
        where TView : IView
    {
        public IReadOnlyCollection<TView> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
