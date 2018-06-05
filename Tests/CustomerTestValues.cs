using CSharpFunctionalExtensions;
using Domain;
using Domain.CustomerAggregate;

namespace Tests
{
	public static class CustomerTestValues
	{
		public static Id MilenkoId => Id.IdFrom("Milenko's Id");
		public static Customer Milenko = new Customer(MilenkoId, "Milenko Jovanovic", 30, Maybe<Address>.None);
		public static Customer OlderMilenko = new Customer(MilenkoId, "Milenko Jovanovic", 50, Maybe<Address>.None);
		public static Customer NewMilenko() => Customer.NewCustomerFrom(Milenko.Name, Milenko.Age, Milenko.MaybeBillingAddress);


		public static Id StankoId => Id.IdFrom("Stanko's Id");
		public static Customer Stanko = new Customer(StankoId, "Stanko Culaja", 30, Maybe<Address>.None);
	}
}