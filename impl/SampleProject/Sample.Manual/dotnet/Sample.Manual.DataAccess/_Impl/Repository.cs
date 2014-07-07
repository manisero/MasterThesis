using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sample.Manual.Domain;
using Cassandra.Data.Linq;
using System.Linq;

namespace Sample.Manual.DataAccess._Impl
{
    public class Repository<TView> : IRepository<TView>
        where TView : class, IView
    {
        private readonly ISessionProvider _sessionProvider;

        private Table<TView> _viewTable;
        private Table<TView> ViewTable
        {
            get { return _viewTable ?? (_viewTable = _sessionProvider.GetSession().GetTable<TView>()); }
        }

        public Repository(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public IReadOnlyCollection<TView> GetAll()
        {
            return ViewTable.Execute().ToList();
        }

        public TView SingleOrDefault(Expression<Func<TView, bool>> predicate)
        {
            return Filter(predicate).SingleOrDefault();
        }

        public IReadOnlyCollection<TView> Filter(Expression<Func<TView, bool>> predicate)
        {
            return ViewTable.Where(predicate).Execute().ToList();
        }
    }
}
