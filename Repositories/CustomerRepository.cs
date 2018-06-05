using Domain.CustomerAggregate;

namespace Repositories
{
	public sealed class CustomerRepository : BaseRepository<Customer>
	{
		public CustomerRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}