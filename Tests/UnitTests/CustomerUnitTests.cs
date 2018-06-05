using FluentAssertions;
using Xunit;

namespace Tests.UnitTests
{
	public sealed class CustomerUnitTests
	{
		[Fact]
		public void two_customers_with_same_id_but_different_values_are_equal()
		{
			CustomerTestValues.Milenko.Should().Be(CustomerTestValues.OlderMilenko);
		}

		[Fact]
		public void two_customers_with_different_ids_are_not_equal()
		{
			CustomerTestValues.Milenko.Should().NotBe(CustomerTestValues.Stanko);
		}

		[Fact]
		public void billing_address_correctly_changed()
		{
			CustomerTestValues.Milenko.SetBillingAddress(AddressTestValues.MilenkoAddress);

			CustomerTestValues.Milenko.MaybeBillingAddress.HasValue.Should().BeTrue("billing address is not set.");
			CustomerTestValues.Milenko.MaybeBillingAddress.Value.Should().Be(AddressTestValues.MilenkoAddress);
		}
	}
}