using Domain;
using Domain.CustomerAggregate;

namespace Repositories
{
	public sealed class CustomerRepository : BaseRepository<Customer>
	{
		public CustomerRepository(
			DatabaseContext databaseContext,
			IEventDispatcher eventDispatcher)
			: base(databaseContext, eventDispatcher)
		{
		}
	}
}