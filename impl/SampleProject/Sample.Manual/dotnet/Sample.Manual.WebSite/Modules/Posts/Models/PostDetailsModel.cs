using System.Collections.Generic;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.WebSite.Modules.Posts.Models
{
    public class PostDetailsModel
    {
        public Post Post { get; set; }

        public IEnumerable<CommentTreeNode> Comments { get; set; }
    }
}
