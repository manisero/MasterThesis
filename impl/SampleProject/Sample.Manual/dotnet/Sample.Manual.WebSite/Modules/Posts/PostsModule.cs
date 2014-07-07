using System;
using System.Collections.Generic;
using Nancy;
using Sample.Manual.DataAccess;
using Sample.Manual.DataAccess.Repositories;
using Sample.Manual.Domain.Views;
using Sample.Manual.WebSite.Modules.Posts.Models;
using Nancy.ModelBinding;
using System.Linq;

namespace Sample.Manual.WebSite.Modules.Posts
{
    public class PostsModule : NancyModule
    {
        private readonly IRepository<Post> _postRepository;
        private readonly ICommentRepository _commentRepository;

        public PostsModule(IRepository<Post> postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;

            Get["/"] = Index;
            Get["/of/{UserName}"] = OfUser;
            Get["/{PostId}"] = PostDetails;
            Post["/{postId}/Comment"] = Comment;
        }

        public dynamic Index(dynamic parameters)
        {
            var posts = _postRepository.GetAll().OrderByDescending(x => x.PostID);
            var model = new IndexModel { Posts = posts };

            return View[model];
        }

        public dynamic OfUser(dynamic parameters)
        {
            var userName = (string)parameters.UserName;
            var posts = _postRepository.Filter(x => x.Author == userName).OrderByDescending(x => x.PostID);
            var model = new IndexModel { Posts = posts };

            return View[model];
        }

        public dynamic PostDetails(dynamic parameters)
        {
            var postId = (Guid)parameters.PostID;
            var model = new PostDetailsModel
                {
                    Post = _postRepository.SingleOrDefault(x => x.PostID == postId),
                    Comments = _commentRepository.GetCommentTreeForPost(postId)
                };

            return View[model];
        }

        public dynamic Comment(dynamic parameters)
        {
            var comment = this.Bind<Domain.Entities.Comment>();

            var model = new PostDetailsModel
                {
                    //PostID = 2,
                    //Title = "My master's thesis subject",
                    //Content = "Actually this is my master's thesis subject.",
                    //Author = "manisero",
                    //Comments = new List<CommentModel>
                    //    {
                    //        new CommentModel
                    //            {
                    //                Author = "Your mom",
                    //                Content = "Good luck with your thesis!"
                    //            },
                    //        new CommentModel
                    //            {
                    //                Author = "Saudi Arabia prince",
                    //                Content = "Spam, spam, spam..."
                    //            },
                    //        new CommentModel
                    //            {
                    //                Author = comment.Author,
                    //                Content = comment.Content
                    //            }
                    //    }
                };

            return View[model];
        }
    }
}
