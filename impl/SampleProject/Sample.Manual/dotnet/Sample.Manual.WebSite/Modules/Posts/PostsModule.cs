using System.Collections.Generic;
using Nancy;
using Sample.Manual.DataAccess._Impl;
using Sample.Manual.Domain.Views;
using Sample.Manual.WebSite.Modules.Posts.Models;
using Nancy.ModelBinding;
using System.Linq;

namespace Sample.Manual.WebSite.Modules.Posts
{
    public class PostsModule : NancyModule
    {
        public PostsModule()
        {
            Get["/"] = Index;
            Get["/{PostId}"] = PostDetails;
            Get["/of/{UserName}"] = OfUser;
            Post["/{postId}/Comment"] = Comment;
        }

        public dynamic Index(dynamic parameters)
        {
            var posts = new Repository<Post>(new SessionProvider()).GetAll().OrderByDescending(x => x.PostID);
            var model = new IndexModel
                {
                    Posts = posts
                };

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

        public dynamic OfUser(dynamic parameters)
        {
            return Index(parameters);
        }

        public dynamic Comment(dynamic parameters)
        {
            var comment = this.Bind<CommentModel>();

            var model = new PostDetailsModel
                {
                    PostID = 2,
                    Title = "My master's thesis subject",
                    Content = "Actually this is my master's thesis subject.",
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
                            comment
                        }
                };

            return View[model];
        }
    }
}
