using Sample.DataAccess;
using Sample.Domain.Events;
using Sample.Domain.Views;

namespace Sample.Logic.EventHandlers
{
    public class PostCommentedEventHandler : IEventHandler<PostCommentedEvent>
    {
        private readonly IUUIDService _uuidService;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Post> _postRepository;

        public PostCommentedEventHandler(IUUIDService uuidService, IRepository<Comment> commentRepository, IRepository<Post> postRepository)
        {
            _uuidService = uuidService;
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }

        public void HandleEvent(PostCommentedEvent @event)
        {
            var comment = new Comment
                {
                    CommentID = _uuidService.CreateUUID(),
                    PostID = @event.PostID,
                    Author = @event.Comment.Author,
                    Content = @event.Comment.Content,
                    ParentCommentID = @event.ParentCommentID
                };

            _commentRepository.AddOrUpdate(comment);

            var post = _postRepository.SingleOrDefault(x => x.PostID == @event.PostID);
            post.CommentsNumber++;

            _postRepository.AddOrUpdate(post);
        }
    }
}
