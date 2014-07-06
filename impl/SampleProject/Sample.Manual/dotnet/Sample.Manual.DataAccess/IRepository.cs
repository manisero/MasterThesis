using System.Collections.Generic;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.DataAccess
{
    public interface IRepository<out TView>
        where TView : class, IView
    {
        IReadOnlyCollection<TView> GetAll();
    }
}
