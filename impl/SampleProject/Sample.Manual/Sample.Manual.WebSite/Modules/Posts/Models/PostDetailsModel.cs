using System.Collections.Generic;

namespace Sample.Manual.WebSite.Modules.Posts.Models
{
    public class PostDetailsModel
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }
    }

    public class CommentModel
    {
        public string Author { get; set; }

        public string Content { get; set; }
    }
}
