using Sample.Manual.DataAccess;
using Sample.Manual.Domain.Events;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.Logic.EventHandlers
{
    public class PostCommentedEventHandler : IEventHandler<PostCommentedEvent>
    {
        private readonly IUUIDService _uuidService;
        private readonly IRepository<Comment> _commentRepository;

        public PostCommentedEventHandler(IUUIDService uuidService, IRepository<Comment> commentRepository)
        {
            _uuidService = uuidService;
            _commentRepository = commentRepository;
        }

        public void HandleEvent(PostCommentedEvent @event)
        {
            var comment = new Comment
                {
                    CommentID = _uuidService.CreateUUID(),
                    PostID = @event.PostID,
                    Author = @event.Comment.Author,
                    Content = @event.Comment.Content
                };

            // TODO: Update Post.NumberOfComments

            _commentRepository.AddOrUpdate(comment);
        }
    }
}
