using System.Collections.Generic;
using Sample.Domain.Views;

namespace Sample.WebSite.Modules.Posts.Models
{
    public class PostDetailsModel
    {
        public Post Post { get; set; }

        public IEnumerable<CommentTreeNode> Comments { get; set; }
    }
}
