using Sample.Manual.DataAccess;
using Sample.Manual.Domain.Events;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.Logic
{
    public class UserUpdatedEventHandler
    {
        private readonly IRepository<User> _userRepository;

        public UserUpdatedEventHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void HandleEvent(UserUpdatedEvent @event)
        {
            var user = _userRepository.SingleOrDefault(x => x.UserName == @event.User.UserName);
        }
    }
}
