using Cassandra;

namespace Sample.DataAccess
{
    public interface ISessionProvider
    {
        ISession GetSession();
    }
}
