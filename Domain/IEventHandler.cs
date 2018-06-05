namespace Domain
{
	public interface IEventHandler<in T>
		where T : IDomainEvent
	{
		void Handle(T domainEvent);
	}

	public interface IEventHandler
	{
		void Handle(IDomainEvent domainEvent);
	}

	public abstract class EventHandler<T> : IEventHandler<T>, IEventHandler
		where T : IDomainEvent
	{
		public abstract void Handle(T domainEvent);

		public void Handle(IDomainEvent domainEvent)
		{
			Handle((T)domainEvent);
		}
	}
}
