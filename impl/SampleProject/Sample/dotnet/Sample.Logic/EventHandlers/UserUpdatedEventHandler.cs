using Sample.DataAccess;
using Sample.Domain.Events;
using Sample.Domain.Views;

namespace Sample.Logic.EventHandlers
{
    public class UserUpdatedEventHandler : IEventHandler<UserUpdatedEvent>
    {
        private readonly IRepository<User> _userRepository;

        public UserUpdatedEventHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void HandleEvent(UserUpdatedEvent @event)
        {
            var userView = _userRepository.SingleOrDefault(x => x.UserName == @event.User.UserName);

            userView.FirstName = @event.User.FirstName;
            userView.LastName = @event.User.LastName;

            _userRepository.AddOrUpdate(userView);
        }
    }
}
