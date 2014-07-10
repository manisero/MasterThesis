using Cassandra;

namespace Sample.DataAccess._Impl
{
    public class SessionProvider : ISessionProvider
    {
        private ISession _session;

        public ISession GetSession()
        {
            if (_session == null)
            {
                var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();

                _session = cluster.Connect("Sample");
            }

            return _session;
        }
    }
}
