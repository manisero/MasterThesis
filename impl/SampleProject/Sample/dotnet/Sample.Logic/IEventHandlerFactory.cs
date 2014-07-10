using Sample.Domain;

namespace Sample.Logic
{
    public interface IEventHandlerFactory
    {
        IEventHandler<TEvent> Create<TEvent>()
            where TEvent : IEvent;
    }
}
