using System;
using System.Collections.Generic;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.DataAccess.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<CommentTreeNode> GetCommentTreeForPost(Guid postId);
    }

    public class CommentTreeNode
    {
        public Comment Comment { get; set; }

        public IEnumerable<CommentTreeNode> Chilren { get; set; }
    }
}
