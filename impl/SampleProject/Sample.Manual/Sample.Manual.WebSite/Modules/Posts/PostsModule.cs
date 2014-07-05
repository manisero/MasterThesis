using System.Collections.Generic;
using Nancy;
using Sample.Manual.WebSite.Modules.Posts.Models;

namespace Sample.Manual.WebSite.Modules.Posts
{
    public class PostsModule : NancyModule
    {
        public PostsModule()
        {
            Get["/"] = Index;
            Get["/PostDetails/{postId}"] = PostDetails;
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
                                    CommentsNumber = 2
                                },
                            new PostModel
                                {
                                    PostID = 1,
                                    Title = "Hello World!",
                                    Content = "First post.",
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
                                }
                        }
                };

            return View[model];
        }
    }
}
