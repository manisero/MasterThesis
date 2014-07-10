using System.Collections.Generic;
using Sample.Domain.Views;

namespace Sample.WebSite.Modules.Posts.Models
{
    public class IndexModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
