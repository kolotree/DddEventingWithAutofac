using Domain;
using MongoDB.Driver;
using Repositories.MongoMappings;

namespace Repositories
{
	public sealed class DatabaseContext
	{
		private readonly IMongoDatabase _database;

		public DatabaseContext(string connectionString)
		{
			Mapper.MapAllClassesToMongoDb();   
			var mongoClient = new MongoClient(connectionString);
			_database = mongoClient.GetDatabase("DddEventingWithAutofac");
		}

		public IMongoCollection<T> GetCollectionFor<T>() where T : AggregateRoot
			=> _database.GetCollection<T>(typeof(T).Name);
	}
}