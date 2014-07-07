using Sample.Manual.Domain;

namespace Sample.Manual.Logic
{
    public interface IEventQueue
    {
        void PutEvent<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}
