using System;
using System.Collections.Generic;
using System.Linq;
using Sample.DataAccess._Impl;
using Sample.Domain.Views;

namespace Sample.DataAccess.Repositories._Impl
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public IEnumerable<CommentTreeNode> GetCommentTreeForPost(Guid postId)
        {
            var comments = Filter(x => x.PostID == postId);
            var result = new List<CommentTreeNode>();

            foreach (var rootComment in comments.Where(x => x.ParentCommentID == null))
            {
                result.Add(CreateHierarchyItem(rootComment, comments));
            }

            return result;
        }

        private CommentTreeNode CreateHierarchyItem(Comment comment, IReadOnlyCollection<Comment> allComments)
        {
            return new CommentTreeNode
                {
                    Comment = comment,
                    Children = allComments.Where(x => x.ParentCommentID == comment.CommentID).Select(x => CreateHierarchyItem(x, allComments))
                };
        }
    }
}
