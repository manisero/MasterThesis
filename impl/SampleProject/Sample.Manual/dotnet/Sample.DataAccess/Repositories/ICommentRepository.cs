using System;
using System.Collections.Generic;
using Sample.Domain.Views;

namespace Sample.DataAccess.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<CommentTreeNode> GetCommentTreeForPost(Guid postId);
    }
}
