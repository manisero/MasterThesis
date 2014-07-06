using System.Collections.Generic;
using Sample.Manual.Domain.Views;
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
    }
}
