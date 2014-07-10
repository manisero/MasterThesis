using System;
using System.Collections.Generic;
using Sample.Core;
using Sample.Domain;
using Sample.Domain.Events;
using Sample.Logic.EventHandlers;

namespace Sample.Logic._Impl
{
    public class EventHandlerFactory : IEventHandlerFactory
    {
        private readonly IServiceResolver _serviceResolver;

        private IDictionary<Type, Type> _handlers;

        public EventHandlerFactory(IServiceResolver serviceResolver)
        {
            _serviceResolver = serviceResolver;
        }

        public IEventHandler<TEvent> Create<TEvent>() 
            where TEvent : IEvent
        {
            if (_handlers == null)
            {
                InitializeHandersDictionary();
            }

            return (IEventHandler<TEvent>)_serviceResolver.Resolve(_handlers[typeof(TEvent)]);
        }

        private void InitializeHandersDictionary()
        {
            _handlers = new Dictionary<Type, Type>();

            _handlers[typeof(UserUpdatedEvent)] = typeof(UserUpdatedEventHandler);
            _handlers[typeof(PostCommentedEvent)] = typeof(PostCommentedEventHandler);
        }
    }
}
