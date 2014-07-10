using Sample.Domain;

namespace Sample.Logic
{
    public interface IEventQueue
    {
        void PutEvent<TEvent>(TEvent @event)
            where TEvent : IEvent;
    }
}
