using System;
using Autofac;
using Mongo2Go;
using Repositories;
using static IoC.Registrator;

namespace Tests.MongoDbIntegrationTests
{
	public abstract class IntegrationTestsBase : IDisposable
	{
		private readonly MongoDbRunner _mongoDbRunner = MongoDbRunner.Start();
		private readonly IContainer _container;

		protected IntegrationTestsBase()
		{
			_container = BuildContainer();
		}

		private IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule(MainRegistratorForIntegrationTestsWith(_mongoDbRunner.ConnectionString));
			return builder.Build();
		}

		protected CustomerRepository GetCustomerRepository()
			=> _container.Resolve<CustomerRepository>();

		public void Dispose()
		{
			_mongoDbRunner.Dispose();
		}
	}
}