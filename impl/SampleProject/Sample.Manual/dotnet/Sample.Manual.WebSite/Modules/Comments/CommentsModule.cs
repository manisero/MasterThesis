using System;
using Nancy;
using Nancy.Responses;
using Sample.Manual.DataAccess;
using Sample.Manual.Domain.Events;
using Sample.Manual.Domain.Views;
using Nancy.ModelBinding;
using Sample.Manual.Logic;

namespace Sample.Manual.WebSite.Modules.Comments
{
    public class CommentsModule : NancyModule
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IEventQueue _eventQueue;

        public CommentsModule(IRepository<Comment> commentRepository, IEventQueue eventQueue)
            : base("/Comments")
        {
            _commentRepository = commentRepository;
            _eventQueue = eventQueue;

            Get["/{CommentID}"] = Details;
            Post["/replyTo/{PostID}"] = ReplyToPost;
            Post["/replyTo/{PostID}/{CommentID}"] = ReplyToComment;
        }

        public dynamic Details(dynamic parameters)
        {
            var commentId = (Guid)parameters.CommentID;
            var comment = _commentRepository.SingleOrDefault(x => x.CommentID == commentId);

            return View[comment];
        }

        public dynamic ReplyToPost(dynamic parameters)
        {
            return Reply(parameters.PostID, null, this.Bind<Domain.Entities.Comment>());
        }

        public dynamic ReplyToComment(dynamic parameters)
        {
            return Reply(parameters.PostID, parameters.CommentID, this.Bind<Domain.Entities.Comment>());
        }

        private RedirectResponse Reply(Guid postId, Guid? postParentId, Domain.Entities.Comment comment)
        {
            var @event = new PostCommentedEvent
            {
                PostID = postId,
                ParentCommentID = postParentId,
                Comment = comment
            };

            _eventQueue.PutEvent(@event);

            return new RedirectResponse(string.Format("/{0}", postId));
        }
    }
}
