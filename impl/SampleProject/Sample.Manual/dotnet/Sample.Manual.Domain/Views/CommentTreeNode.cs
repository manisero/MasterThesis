using System.Collections.Generic;

namespace Sample.Manual.Domain.Views
{
    public class CommentTreeNode
    {
        public Comment Comment { get; set; }

        public IEnumerable<CommentTreeNode> Children { get; set; }
    }
}
