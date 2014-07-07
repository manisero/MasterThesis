using Sample.Manual.Domain;

namespace Sample.Manual.Logic
{
    public interface IEventHandler<TEvent>
        where TEvent : IEvent
    {
        void HandleEvent(TEvent @event);
    }
}
