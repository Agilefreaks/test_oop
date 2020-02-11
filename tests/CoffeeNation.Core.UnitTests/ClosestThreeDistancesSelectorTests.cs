using System;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.UnitTestsCommon;
using Xunit;

namespace CoffeeNation.Core.UnitTests
{
    public class ClosestThreeDistancesSelectorTests
    {
        [Fact]
        public async Task TestThat_SelectDistances_When_InputDistancesListIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var distanceSelector = new ClosestThreeDistancesSelector();

            // Act
            async Task Act() => await distanceSelector.SelectDistances(MockObjects.NullShopDistances);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_SelectDistances_When_InputDistancesListIsLessThanThree_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var distanceSelector = new ClosestThreeDistancesSelector();

            // Act
            async Task Act() => await distanceSelector.SelectDistances(MockObjects.LessThanThreeShopDistances);

            // Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(Act);
        }

        [Fact]
        public async Task TestThat_SelectDistances_When_InputDistancesListIsValid_Returns_NotNullDistanceList()
        {
            // Arrange
            var distanceSelector = new ClosestThreeDistancesSelector();

            // Act
            var distances = await distanceSelector.SelectDistances(MockObjects.AllShopDistances);

            // Assert
            Assert.NotNull(distances);
        }

        [Fact]
        public async Task TestThat_SelectDistances_When_InputDistancesListIsValid_Returns_ExpectedNumberOfElements()
        {
            // Arrange
            var distanceSelector = new ClosestThreeDistancesSelector();

            // Act
            var distances = await distanceSelector.SelectDistances(MockObjects.AllShopDistances);

            // Assert
            Assert.Equal(MockValues.DefaultOutputDistancesCount, distances.Count());
        }
    }
}
