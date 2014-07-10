using System;
using Nancy;
using System.Linq;
using Sample.DataAccess;
using Sample.DataAccess.Repositories;
using Sample.Domain.Views;
using Sample.WebSite.Modules.Posts.Models;

namespace Sample.WebSite.Modules.Posts
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
            Get["/{PostId}"] = Details;
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

        public dynamic Details(dynamic parameters)
        {
            var postId = (Guid)parameters.PostID;
            var model = new PostDetailsModel
                {
                    Post = _postRepository.SingleOrDefault(x => x.PostID == postId),
                    Comments = _commentRepository.GetCommentTreeForPost(postId)
                };

            return View[model];
        }
    }
}
