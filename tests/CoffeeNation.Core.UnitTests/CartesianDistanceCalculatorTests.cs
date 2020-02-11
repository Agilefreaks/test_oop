using System;
using System.Threading.Tasks;
using CoffeeNation.UnitTestsCommon;
using Xunit;

namespace CoffeeNation.Core.UnitTests
{
    public class CartesianDistanceCalculatorTests
    {
        [Fact]
        public async Task TestThat_CalculateDistanceToDestination_When_SourceIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var distanceCalculator = new CartesianDistanceCalculator();

            // Act
            async Task Act() => await distanceCalculator.CalculateDistanceToDestination(MockObjects.NullUserLocation, MockObjects.ShopLocation1);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_CalculateDistanceToDestination_When_DestinationIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var distanceCalculator = new CartesianDistanceCalculator();

            // Act
            async Task Act() => await distanceCalculator.CalculateDistanceToDestination(MockObjects.UserLocation1, MockObjects.NullShopLocation);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_CalculateDistanceToDestination_When_SourceAndDestinationAreNotNull_Returns_NotNullDistance()
        {
            // Arrange
            var distanceCalculator = new CartesianDistanceCalculator();

            // Act
            var distance = await distanceCalculator.CalculateDistanceToDestination(MockObjects.UserLocation1, MockObjects.ShopLocation1);

            // Assert
            Assert.NotNull(distance);
        }

        [Fact]
        public async Task TestThat_CalculateDistanceToDestination_When_SourceAndDestinationAreNotNull_Returns_DistanceWithCartesianDistanceValue()
        {
            // Arrange
            var distanceCalculator = new CartesianDistanceCalculator();

            var source = MockObjects.UserLocation1;
            var destination = MockObjects.ShopLocation1;

            // Act
            var distance = await distanceCalculator.CalculateDistanceToDestination(source, destination);

            // Assert
            Assert.Equal(GetCartesianDistance(source.X, source.Y, destination.X, destination.Y), distance.Value);
        }

        [Fact]
        public async Task TestThat_CalculateDistanceToDestination_When_SourceAndDestinationAreNotNull_Returns_DistanceWithSameTagAsDestination()
        {
            // Arrange
            var distanceCalculator = new CartesianDistanceCalculator();

            var source = MockObjects.UserLocation1;
            var destination = MockObjects.ShopLocation1;

            // Act
            var distance = await distanceCalculator.CalculateDistanceToDestination(source, destination);

            // Assert
            Assert.Equal(destination.Tag, distance.Tag);
        }

        private double GetCartesianDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
