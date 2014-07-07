using System;

namespace Sample.Manual.Domain.Views
{
    public class Comment : IView
    {
        public Guid CommentID { get; set; }

        public Guid PostID { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public Guid? ParentCommentID { get; set; }
    }
}
