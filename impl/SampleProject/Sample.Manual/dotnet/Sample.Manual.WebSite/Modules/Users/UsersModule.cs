using Nancy;
using Sample.Manual.DataAccess;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.WebSite.Modules.Users
{
    public class UsersModule : NancyModule
    {
        private readonly IRepository<User> _userRepository;

        public UsersModule(IRepository<User> userRepository) : base("/Users")
        {
            _userRepository = userRepository;

            Get["/{UserName}"] = Details;
        }

        public dynamic Details(dynamic parameters)
        {
            var userName = (string)parameters.UserName;
            var user = _userRepository.SingleOrDefault(x => x.UserName == userName);

            return View[user];
        }
    }
}
