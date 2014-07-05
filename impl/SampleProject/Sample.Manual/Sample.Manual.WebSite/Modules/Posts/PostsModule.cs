using Nancy;

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
            return View["Index"];
        }
    }
}
