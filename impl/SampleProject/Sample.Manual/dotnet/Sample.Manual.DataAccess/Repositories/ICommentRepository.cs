using System;
using System.Collections.Generic;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.DataAccess.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<CommentTreeNode> GetCommentTreeForPost(Guid postId);
    }
}
