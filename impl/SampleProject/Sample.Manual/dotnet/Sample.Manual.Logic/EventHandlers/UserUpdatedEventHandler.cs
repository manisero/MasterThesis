using Sample.Manual.DataAccess;
using Sample.Manual.Domain.Events;
using Sample.Manual.Domain.Views;

namespace Sample.Manual.Logic.EventHandlers
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
