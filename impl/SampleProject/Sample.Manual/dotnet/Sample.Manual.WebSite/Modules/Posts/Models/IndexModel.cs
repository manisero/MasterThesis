using System.Collections.Generic;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.WebSite.Modules.Posts.Models
{
    public class IndexModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
