using System.Collections.Generic;

namespace Sample.WebSite.Modules.Posts.Models
{
    public class CommentModel
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public IEnumerable<CommentModel> Replies { get; set; }
    }
}
