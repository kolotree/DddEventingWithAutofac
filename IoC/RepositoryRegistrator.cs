using Autofac;
using Repositories;

namespace IoC
{
    internal sealed class RepositoryRegistrator : Module
    {
	    private readonly string _connectionString;

	    public RepositoryRegistrator(string connectionString)
	    {
		    _connectionString = connectionString;
	    }

	    protected override void Load(ContainerBuilder builder)
	    {
		    RegisterDatabaseContextAsSingleInstance(builder);
		    RegisterRepositories(builder);
	    }

	    private void RegisterDatabaseContextAsSingleInstance(ContainerBuilder builder)
	    {
		    builder.RegisterType<DatabaseContext>()
			    .WithParameter("connectionString", _connectionString)
			    .SingleInstance();
	    }

	    private void RegisterRepositories(ContainerBuilder builder)
	    {
		    builder.RegisterType<CustomerRepository>();
	    }
	}
}
