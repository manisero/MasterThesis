using Sample.Manual.Domain;

namespace Sample.Manual.Logic
{
    public interface IEventHandlerFactory
    {
        IEventHandler<TEvent> Create<TEvent>()
            where TEvent : IEvent;
    }
}
