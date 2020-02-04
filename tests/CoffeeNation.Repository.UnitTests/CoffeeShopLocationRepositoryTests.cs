using System;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Repository.UnitTests
{
    public class CoffeeShopLocationRepositoryTests
    {
        [Fact]
        public async Task TestThat_GetCoffeeShopLocations_When_DataReaderThrowsDataValidationException_Throws_DataValidationException()
        {
            // Arrange
            var dataReaderMock = new Mock<ICoffeeShopLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadCoffeeShopLocations())
                .Throws<DataValidationException>();

            var coffeeShopLocationRepository = new CoffeeShopLocationRepository(dataReaderMock.Object);

            // Act
            async Task Act() => await coffeeShopLocationRepository.GetCoffeeShopLocations();

            // Assert
            await Assert.ThrowsAsync<DataValidationException>(Act);
        }

        [Fact]
        public async Task TestThat_GetCoffeeShopLocations_When_DataReaderReturnsNoItems_Returns_EmptyLocationList()
        {
            // Arrange
            var dataReaderMock = new Mock<ICoffeeShopLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadCoffeeShopLocations())
                .ReturnsAsync(MockData.EmptyShopLocations);

            var coffeeShopLocationRepository = new CoffeeShopLocationRepository(dataReaderMock.Object);

            // Act
            var locations = await coffeeShopLocationRepository.GetCoffeeShopLocations();

            // Assert
            Assert.Empty(locations);
        }


        [Fact]
        public async Task TestThat_GetCoffeeShopLocations_When_DataReaderReturnsItems_Returns_NotNullLocationList()
        {
            // Arrange
            var dataReaderMock = new Mock<ICoffeeShopLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadCoffeeShopLocations())
                .ReturnsAsync(MockData.ValidCoffeeShopLocations);

            var coffeeShopLocationRepository = new CoffeeShopLocationRepository(dataReaderMock.Object);

            // Act
            var locations = await coffeeShopLocationRepository.GetCoffeeShopLocations();

            // Assert
            Assert.NotNull(locations);
        }

        [Fact]
        public async Task TestThat_GetCoffeeShopLocations_When_DataReaderReturnsItems_Returns_ExpectedNumberOfElements()
        {
            // Arrange
            var dataReaderMock = new Mock<ICoffeeShopLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadCoffeeShopLocations())
                .ReturnsAsync(MockData.ValidCoffeeShopLocations);

            var coffeeShopLocationRepository = new CoffeeShopLocationRepository(dataReaderMock.Object);

            // Act
            var locations = await coffeeShopLocationRepository.GetCoffeeShopLocations();

            // Assert
            Assert.Equal(5, locations.Count());
        }

    }
}
