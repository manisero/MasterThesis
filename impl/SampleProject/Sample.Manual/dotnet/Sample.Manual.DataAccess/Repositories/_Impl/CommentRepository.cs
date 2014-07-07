using System;
using System.Collections.Generic;
using Sample.Manual.DataAccess._Impl;
using Sample.Manual.Domain.Views;
using System.Linq;

namespace Sample.Manual.DataAccess.Repositories._Impl
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public IEnumerable<CommentTreeNode> GetCommentTreeForPost(Guid postId)
        {
            var comments = Filter(x => x.PostID == postId).Reverse().ToList();
            var result = new List<CommentTreeNode>();

            foreach (var rootComment in comments.Where(x => x.ParentCommentID == null))
            {
                result.Add(CreateHierarchyItem(rootComment, comments));
            }

            return result;
        }

        private CommentTreeNode CreateHierarchyItem(Comment comment, ICollection<Comment> allComments)
        {
            return new CommentTreeNode
                {
                    Comment = comment,
                    Children = allComments.Where(x => x.ParentCommentID == comment.CommentID).Select(x => CreateHierarchyItem(x, allComments))
                };
        }
    }
}
