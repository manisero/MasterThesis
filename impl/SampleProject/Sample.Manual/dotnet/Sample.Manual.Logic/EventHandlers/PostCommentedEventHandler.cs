using Sample.Manual.DataAccess;
using Sample.Manual.Domain.Events;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.Logic.EventHandlers
{
    public class PostCommentedEventHandler : IEventHandler<PostCommentedEvent>
    {
        private readonly IRepository<Comment> _commentRepository;

        public PostCommentedEventHandler(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void HandleEvent(PostCommentedEvent @event)
        {
            var comment = new Comment
                {
                    PostID = @event.PostID,
                    Author = @event.Comment.Author,
                    Content = @event.Comment.Content
                };

            _commentRepository.AddOrUpdate(comment);
        }
    }
}
