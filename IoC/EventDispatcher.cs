using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Domain;

namespace IoC
{
	internal sealed class EventDispatcher : IEventDispatcher
	{
		private readonly IComponentContext _componentContext;

		public EventDispatcher(IComponentContext componentContext)
		{
			_componentContext = componentContext;
		}

		public IReadOnlyList<IDomainEvent> DispatchAll(IReadOnlyList<IDomainEvent> domainEvents) => domainEvents
			.Select(Dispatch)
			.ToList();

		private IDomainEvent Dispatch(IDomainEvent domainEvent) =>
			GetEventHandlersFor(domainEvent)
				.Select(eventHandler => DispatchTo(domainEvent, eventHandler))
				.Last();

		private IReadOnlyList<IEventHandler> GetEventHandlersFor(IDomainEvent domainEvent)
		{
			var genericEventHandlerType = typeof(IEventHandler<>).MakeGenericType(domainEvent.GetType());
			var genericEventHandlerEnumerableType = typeof(IEnumerable<>).MakeGenericType(genericEventHandlerType);
			return ((IEnumerable)_componentContext.Resolve(genericEventHandlerEnumerableType))
				.Cast<IEventHandler>()
				.ToList();
		}

		private IDomainEvent DispatchTo(IDomainEvent domainEvent, IEventHandler eventHandler)
		{
			eventHandler.Handle(domainEvent);
			return domainEvent;
		}
	}
}