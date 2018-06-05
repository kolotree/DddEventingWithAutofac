using Domain;
using Domain.CustomerAggregate;
using static Tests.AddressTestValues;

namespace Tests
{
	public static class CustomerTestValues
	{
		private static Id MilenkoId => Id.IdFrom("Milenko's Id");
		public static readonly Customer Milenko = new Customer(MilenkoId, "Milenko Jovanovic", 30, MilenkoAddress);
	}
}