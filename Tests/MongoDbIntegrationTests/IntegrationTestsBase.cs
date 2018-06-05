using System;
using Domain;
using Mongo2Go;
using Repositories;

namespace Tests.MongoDbIntegrationTests
{
	public abstract class IntegrationTestsBase : IDisposable
	{
		private readonly MongoDbRunner _mongoDbRunner = MongoDbRunner.Start();
		private readonly DatabaseContext _databaseContext;
		private readonly IEventDispatcher _eventDispatcher = null;

		protected IntegrationTestsBase()
		{
			_databaseContext = new DatabaseContext(_mongoDbRunner.ConnectionString);
		}

		protected CustomerRepository GetCustomerRepository()
			=> new CustomerRepository(_databaseContext, _eventDispatcher);

		public void Dispose()
		{
			_mongoDbRunner.Dispose();
		}
	}
}