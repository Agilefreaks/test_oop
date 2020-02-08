using System;
using System.Threading.Tasks;
using CoffeeNation.Data.Formatter;
using CoffeeNation.UnitTestsCommon;
using Xunit;

namespace CoffeeNation.Data.UnitTests.Formatter
{
    public class CoffeeShopDistanceFormatterTests
    {
        [Fact]
        public async Task TestThat_GetFormattedDistance_When_DistanceIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var distanceFormatter = new CoffeeShopDistanceFormatter();

            // Act
            async Task Act() => await distanceFormatter.GetFormattedDistance(MockData.NullShopDistance);

            // Assert
            await Assert.ThrowsAnyAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_GetFormattedDistance_When_DistanceIsValid_Returns_NotNullOrEmptyString()
        {
            // Arrange
            var distanceFormatter = new CoffeeShopDistanceFormatter();

            // Act
            var formattedDistance = await distanceFormatter.GetFormattedDistance(MockData.ShopDistance1);

            // Assert
            Assert.False(string.IsNullOrEmpty(formattedDistance));
        }

        [Fact]
        public async Task TestThat_GetFormattedDistance_When_DistanceIsValid_Returns_ExpectedFormattedDistance()
        {
            // Arrange
            var distanceFormatter = new CoffeeShopDistanceFormatter();

            // Act
            var formattedDistance = await distanceFormatter.GetFormattedDistance(MockData.ShopDistance1);

            // Assert
            Assert.Equal(MockData.FormattedCoffeeShopDistance1, formattedDistance);
        }
    }
}
