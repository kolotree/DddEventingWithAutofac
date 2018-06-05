using Domain.CustomerAggregate;
using FluentAssertions;
using Xunit;

namespace Tests.UnitTests
{
	public sealed class AddressUnitTests
	{
		[Fact]
		public void two_different_addresses_are_not_equal()
		{
			AddressTestValues.MilenkoAddress.Should().NotBe(AddressTestValues.StankoAddress);
		}

		[Fact]
		public void two_same_addresses_are_equal()
		{
			new Address("Street", "Number", "City")
				.Should()
				.Be(new Address("Street", "Number", "City"));
		}
	}
}