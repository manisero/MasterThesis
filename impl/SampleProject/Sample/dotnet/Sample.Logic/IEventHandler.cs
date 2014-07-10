using Sample.Domain;

namespace Sample.Logic
{
    public interface IEventHandler<TEvent>
        where TEvent : IEvent
    {
        void HandleEvent(TEvent @event);
    }
}
