using Cassandra;

namespace Sample.Manual.DataAccess
{
    public interface ISessionProvider
    {
        ISession GetSession();
    }
}
