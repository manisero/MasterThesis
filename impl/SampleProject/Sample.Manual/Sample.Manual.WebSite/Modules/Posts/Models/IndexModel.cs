using System.Collections.Generic;

namespace Sample.Manual.WebSite.Modules.Posts.Models
{
    public class IndexModel
    {
        public IEnumerable<PostModel> Posts { get; set; }
    }
}
