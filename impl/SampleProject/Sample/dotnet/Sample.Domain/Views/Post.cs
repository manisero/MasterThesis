using System;

namespace Sample.Domain.Views
{
    public class Post : IView
    {
        public Guid PostID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public int CommentsNumber { get; set; }
    }
}
