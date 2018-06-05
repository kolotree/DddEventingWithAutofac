using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Domain;
using MongoDB.Driver;

namespace Repositories
{
	public abstract class BaseRepository<T> where T : AggregateRoot
	{
		protected readonly IMongoCollection<T> MongoCollection;
		
		public BaseRepository(DatabaseContext databaseContext)
		{
			MongoCollection = databaseContext.GetCollectionFor<T>();
		}

		public Maybe<T> GetBy(Id id)
			=> MongoCollection.Find(item => item.Id == id).SingleOrDefault();

		public IList<T> GetAll()
			=> MongoCollection.AsQueryable().ToList();

		public T Save(T aggregateRoot)
		{
			var updateOptions = new UpdateOptions { IsUpsert = true };
			MongoCollection.ReplaceOne(item => item.Id == aggregateRoot.Id, aggregateRoot, updateOptions);
			return aggregateRoot;
		}
	}
}