namespace Sample.Manual.Domain.Views
{
    public class Post : IView
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public int CommentsNumber { get; set; }
    }
}
