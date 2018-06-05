namespace Domain.CustomerAggregate
{
	public sealed class Customer : AggregateRoot
	{
		public string Name { get; }
		public int Age { get; }
		public Address BillingAddress { get; private set;}

		public Customer(
			Id id,
			string name,
			int age,
			Address billingAddress)
		{
			Id = id;
			Name = name;
			Age = age;
			BillingAddress = BillingAddress;
		}

		public static Customer NewCustomerFrom(string name, int age, Address address)
			=> new Customer(Id.None, name, age, address);

		public Customer ChangeBillingAddress(Address address)
		{
			BillingAddress = address;
			return this;
		}
	}
}