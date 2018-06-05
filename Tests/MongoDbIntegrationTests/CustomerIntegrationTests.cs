using System.Linq;
using Domain;
using FluentAssertions;
using Xunit;

namespace Tests.MongoDbIntegrationTests
{
	public sealed class CustomerIntegrationTests : IntegrationTestsBase
	{
		[Fact]
		public void persisted_Milenko_has_id_set_to_some_non_None_value()
		{
			var newMilenko = CustomerTestValues.NewMilenko();

			var repository = GetCustomerRepository();
			repository.Save(newMilenko);

			var persistedMilenko = repository.GetAll().First();
			persistedMilenko.Id.Should().NotBe(null, "Id has to be set to some value.");
			persistedMilenko.Id.Should().NotBe(Id.None, "Id has to be set to some value.");
		}

		[Fact]
		public void after_saving_both_new_Milenko_and_persisted_Milenko_have_equal_ids()
		{
			var newMilenko = CustomerTestValues.NewMilenko();

			var repository = GetCustomerRepository();
			repository.Save(newMilenko);

			var persistedMilenko = repository.GetAll().First();
			persistedMilenko.Should().Be(newMilenko);
		}

		[Fact]
		public void milenko_values_are_persisted_into_db()
		{
			var newMilenko = CustomerTestValues.NewMilenko();

			var repository = GetCustomerRepository();
			repository.Save(newMilenko);

			var persistedMilenko = repository.GetAll().First();
			persistedMilenko.Name.Should().Be(newMilenko.Name);
			persistedMilenko.Age.Should().Be(newMilenko.Age);
			persistedMilenko.MaybeBillingAddress.Should().Be(newMilenko.MaybeBillingAddress);
		}
	}
}