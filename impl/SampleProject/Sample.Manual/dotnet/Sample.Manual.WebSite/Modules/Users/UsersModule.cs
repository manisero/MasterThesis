using Nancy;
using Sample.Manual.WebSite.Modules.Users.Models;

namespace Sample.Manual.WebSite.Modules.Users
{
    public class UsersModule : NancyModule
    {
        public UsersModule() : base("/Users")
        {
            Get["/{UserName}"] = Details;
        }

        public dynamic Details(dynamic parameters)
        {
            var model = new UserModel
                {
                    UserName = parameters.UserName,
                    FirstName = "Joe",
                    LastName = "Doe"
                };

            return View[model];
        }
    }
}
