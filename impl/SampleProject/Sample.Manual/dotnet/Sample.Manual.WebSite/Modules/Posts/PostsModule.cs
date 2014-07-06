using System.Collections.Generic;
using Nancy;
using Sample.Manual.DataAccess;
using Sample.Manual.Domain.Entities;
using Sample.Manual.Domain.Views;
using Sample.Manual.WebSite.Modules.Posts.Models;
using Nancy.ModelBinding;
using System.Linq;

namespace Sample.Manual.WebSite.Modules.Posts
{
    public class PostsModule : NancyModule
    {
        private readonly IRepository<Post> _postRepository;

        public PostsModule(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;

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
            var model = new PostDetailsModel
                {
                    PostID = 2,
                    Title = "My master's thesis subject",
                    Content = "Actually this is my master's thesis subject.",
                    Author = "manisero",
                    Comments = new List<CommentModel>
                        {
                            new CommentModel
                                {
                                    Author = "Your mom",
                                    Content = "Good luck with your thesis!",
                                    Replies = new List<CommentModel>
                                        {
                                            new CommentModel
                                                {
                                                    Author = "manisero",
                                                    Content = "Thanks, mom",
                                                    Replies = new List<CommentModel>
                                                        {
                                                            new CommentModel
                                                                {
                                                                    Author = "Your mom",
                                                                    Content = "Yrw."
                                                                }
                                                        }
                                                },
                                            new CommentModel
                                                {
                                                    Author = "Your mom",
                                                    Content = "Ah, and eat your dinner"
                                                }
                                        }
                                },
                            new CommentModel
                                {
                                    Author = "Saudi Arabia prince",
                                    Content = "Spam, spam, spam..."
                                }
                        }
                };

            return View[model];
        }

        public dynamic Comment(dynamic parameters)
        {
            var comment = this.Bind<Comment>();

            var model = new PostDetailsModel
                {
                    PostID = 2,
                    Title = "My master's thesis subject",
                    Content = "Actually this is my master's thesis subject.",
                    Author = "manisero",
                    Comments = new List<CommentModel>
                        {
                            new CommentModel
                                {
                                    Author = "Your mom",
                                    Content = "Good luck with your thesis!"
                                },
                            new CommentModel
                                {
                                    Author = "Saudi Arabia prince",
                                    Content = "Spam, spam, spam..."
                                },
                            new CommentModel
                                {
                                    Author = comment.Author,
                                    Content = comment.Content
                                }
                        }
                };

            return View[model];
        }
    }
}
