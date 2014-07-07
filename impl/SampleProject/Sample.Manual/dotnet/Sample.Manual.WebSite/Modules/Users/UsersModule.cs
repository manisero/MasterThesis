using Nancy;
using Sample.Manual.DataAccess;
using Sample.Manual.Domain.Events;
using Sample.Manual.Domain.Views;
using Nancy.ModelBinding;
using Sample.Manual.Logic;

namespace Sample.Manual.WebSite.Modules.Users
{
    public class UsersModule : NancyModule
    {
        private readonly IRepository<User> _userRepository;
        private readonly IEventHandler<UserUpdatedEvent> _handler;

        public UsersModule(IRepository<User> userRepository, IEventHandler<UserUpdatedEvent> handler) : base("/Users")
        {
            _userRepository = userRepository;
            _handler = handler;

            Get["/{UserName}"] = Details;
            Post["/{UserName}"] = Update;
        }

        public dynamic Details(dynamic parameters)
        {
            var userName = (string)parameters.UserName;
            var user = _userRepository.SingleOrDefault(x => x.UserName == userName);

            return View[user];
        }

        public dynamic Update(dynamic parameters)
        {
            var user = this.Bind<Domain.Entities.User>();
            var @event = new UserUpdatedEvent
                {
                    User = user
                };

            _handler.HandleEvent(@event);

            return Details(parameters);
        }
    }
}
