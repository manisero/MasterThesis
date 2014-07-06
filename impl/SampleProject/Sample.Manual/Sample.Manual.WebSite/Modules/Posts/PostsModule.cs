using System.Collections.Generic;
using Nancy;
using Sample.Manual.WebSite.Modules.Posts.Models;
using Nancy.ModelBinding;

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
            var model = new IndexModel
                {
                    Posts = new List<PostModel>
                        {
                            new PostModel
                                {
                                    PostID = 2,
                                    Title = "My master's thesis subject",
                                    Content = "Actually this is my master's thesis subject.",
                                    Author = "manisero",
                                    CommentsNumber = 2
                                },
                            new PostModel
                                {
                                    PostID = 1,
                                    Title = "Hello World!",
                                    Content = "First post.",
                                    Author = "manisero",
                                    CommentsNumber = 3
                                }
                        }
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
                                                    Content = "Thanks, mom!"
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
