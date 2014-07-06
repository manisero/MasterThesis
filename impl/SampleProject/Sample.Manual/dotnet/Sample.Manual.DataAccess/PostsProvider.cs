using System.Collections.Generic;
using Cassandra;
using System.Linq;
using Cassandra.Data.Linq;

namespace Sample.Manual.DataAccess
{
    public class Post
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public int CommentsNumber { get; set; }
    }

    public class PostsProvider
    {
        public IEnumerable<Post> GetAll()
        {
            var cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            var session = cluster.Connect("Sample_Manual");

            var result = session.Execute(@"select * from ""Posts""");

            var postsTable = session.GetTable<Post>("Posts").Execute().First();

            return null;
        }
    }
}
