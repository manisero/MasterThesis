using Cassandra;

namespace Sample.Manual.DataAccess._Impl
{
    public class SessionProvider : ISessionProvider
    {
        public ISession GetSession()
        {
            var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();

            return cluster.Connect("Sample_Manual");
        }
    }
}
