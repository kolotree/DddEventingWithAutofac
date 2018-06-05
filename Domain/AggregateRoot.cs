using System.Collections.Generic;

namespace Domain
{
	public abstract class AggregateRoot : Entity
	{
		private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
		public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

		protected void AddDomainEvent(IDomainEvent newEvent)
		{
			_domainEvents.Add(newEvent);
		}

		public void ClearEvents()
		{
			_domainEvents.Clear();
		}
	}
}