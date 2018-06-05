using Autofac;

namespace IoC
{
    public sealed class Registrator : Module
	{
	    private readonly string _connectionString;

		private Registrator(string connectionString)
	    {
		    _connectionString = connectionString;
	    }

		public static Registrator MainRegistratorForIntegrationTestsWith(string connectionString)
		    => new Registrator(connectionString);

		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			builder.RegisterModule<EventHandlerRegistrator>();
			builder.RegisterModule(new RepositoryRegistrator(_connectionString));
		}
	}
}
