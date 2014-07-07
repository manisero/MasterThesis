using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sample.Manual.Domain;

namespace Sample.Manual.DataAccess
{
    public interface IRepository<TView>
        where TView : class, IView
    {
        IReadOnlyCollection<TView> GetAll();

        TView SingleOrDefault(Expression<Func<TView, bool>> predicate);

        IReadOnlyCollection<TView> Filter(Expression<Func<TView, bool>> predicate);

        void AddOrUpdate(TView item);
    }
}
