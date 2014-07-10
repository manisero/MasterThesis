using System;
using System.Linq;

namespace Sample.DataAccess._Impl
{
    public class UUIDService : IUUIDService
    {
        private readonly ISessionProvider _sessionProvider;

        public UUIDService(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public Guid CreateUUID()
        {
            _sessionProvider.GetSession().Execute("CREATE TABLE temp (value int PRIMARY KEY);");
            _sessionProvider.GetSession().Execute("INSERT INTO temp (value) VALUES (0);");

            var nowResult = _sessionProvider.GetSession().Execute("SELECT now() FROM temp;");

            _sessionProvider.GetSession().Execute("DROP TABLE temp;");

            return nowResult.Single().GetValue<Guid>(0);
        }
    }
}
