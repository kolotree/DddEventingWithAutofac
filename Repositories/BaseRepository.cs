using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Domain;
using MongoDB.Driver;

namespace Repositories
{
	public abstract class BaseRepository<T> where T : AggregateRoot
	{
		private readonly IEventDispatcher _eventDispatcher;
		private readonly IMongoCollection<T> _mongoCollection;

		protected BaseRepository(
			DatabaseContext databaseContext,
			IEventDispatcher eventDispatcher)
		{
			_eventDispatcher = eventDispatcher;
			_mongoCollection = databaseContext.GetCollectionFor<T>();
		}

		public IList<T> GetAll()
			=> _mongoCollection.AsQueryable().ToList();

		public T Save(T aggregateRoot)
		{
			var updateOptions = new UpdateOptions { IsUpsert = true };
			_mongoCollection.ReplaceOne(item => item.Id == aggregateRoot.Id, aggregateRoot, updateOptions);
			return PurgeAllEventsFor(aggregateRoot);
		}
		
		private T PurgeAllEventsFor(T aggregateRoot)
		{
			_eventDispatcher.DispatchAll(aggregateRoot.DomainEvents);
			aggregateRoot.ClearEvents();
			return aggregateRoot;
		}
	}
}