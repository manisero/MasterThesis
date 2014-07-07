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
        private readonly IEventQueue _eventQueue;

        public UsersModule(IRepository<User> userRepository, IEventQueue eventQueue)
            : base("/Users")
        {
            _userRepository = userRepository;
            _eventQueue = eventQueue;

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
            var @event = new UserUpdatedEvent
                {
                    User = this.Bind<Domain.Entities.User>()
                };

            _eventQueue.PutEvent(@event);

            return Details(parameters);
        }
    }
}
