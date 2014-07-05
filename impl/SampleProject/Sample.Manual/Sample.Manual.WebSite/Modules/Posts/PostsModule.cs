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
        }

        public dynamic Index(dynamic parameters)
        {
            var model = new List<Post>
                {
                    new Post
                        {
                            Title = "My master's thesis subject",
                            Content = "Actually this is my master's thesis subject.",
                            CommentsNumber = 5
                        },
                    new Post
                        {
                            Title = "Hello World!",
                            Content = "First post.",
                            CommentsNumber = 3
                        }
                };

            return View["Index", model];
        }
    }
}
