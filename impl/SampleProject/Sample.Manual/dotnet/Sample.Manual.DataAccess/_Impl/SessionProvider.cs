using Cassandra;

namespace Sample.Manual.DataAccess._Impl
{
    public class SessionProvider : ISessionProvider
    {
        private ISession _session;

        public ISession GetSession()
        {
            if (_session == null)
            {
                var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();

                _session = cluster.Connect("Sample_Manual");
            }

            return _session;
        }
    }
}
