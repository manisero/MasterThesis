using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.DataAccess
{
    public interface IRepository<TView>
        where TView : class, IView
    {
        IReadOnlyCollection<TView> GetAll();

        IReadOnlyCollection<TView> Filter(Expression<Func<TView, bool>> predicate);
    }
}
