using Sample.Manual.Domain.Entities;

namespace Sample.Manual.Domain.Events
{
    public class UserUpdatedEvent : IEvent
    {
        public User User { get; set; }
    }
}
