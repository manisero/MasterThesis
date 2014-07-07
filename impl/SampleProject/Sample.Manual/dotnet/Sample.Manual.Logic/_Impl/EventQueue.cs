using Sample.Manual.Domain;

namespace Sample.Manual.Logic._Impl
{
    public class EventQueue : IEventQueue
    {
        private readonly IEventHandlerFactory _eventHandlerFactory;

        public EventQueue(IEventHandlerFactory eventHandlerFactory)
        {
            _eventHandlerFactory = eventHandlerFactory;
        }

        public void PutEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handler = _eventHandlerFactory.Create<TEvent>();

            handler.HandleEvent(@event);
        }
    }
}
