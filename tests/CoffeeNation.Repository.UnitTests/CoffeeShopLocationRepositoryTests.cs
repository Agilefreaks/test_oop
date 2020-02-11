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
        public async Task TestThat_GetCoffeeShopLocations_When_DataReaderThrowsDataValidationException_Throws_DataValidationExceptionWithExpectedMessage()
        {
            // Arrange
            var dataReaderMock = new Mock<ICoffeeShopLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadCoffeeShopLocations())
                .Throws(new DataValidationException(MockValues.CsvDataValidationExceptionMessage));

            var coffeeShopLocationRepository = new CoffeeShopLocationRepository(dataReaderMock.Object);

            // Act
            async Task Act() => await coffeeShopLocationRepository.GetCoffeeShopLocations();

            // Assert
            var exception = await Assert.ThrowsAsync<DataValidationException>(Act);
            Assert.Equal(MockValues.CsvDataValidationExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_GetCoffeeShopLocations_When_DataReaderThrowsDataProviderException_Throws_DataProviderExceptionWithExpectedMessage()
        {
            // Arrange
            var dataReaderMock = new Mock<ICoffeeShopLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadCoffeeShopLocations())
                .Throws(new DataProviderException(MockValues.CsvDataProviderExceptionMessage));

            var coffeeShopLocationRepository = new CoffeeShopLocationRepository(dataReaderMock.Object);

            // Act
            async Task Act() => await coffeeShopLocationRepository.GetCoffeeShopLocations();

            // Assert
            var exception = await Assert.ThrowsAsync<DataProviderException>(Act);
            Assert.Equal(MockValues.CsvDataProviderExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_GetCoffeeShopLocations_When_DataReaderReturnsNoItems_Returns_EmptyLocationList()
        {
            // Arrange
            var dataReaderMock = new Mock<ICoffeeShopLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadCoffeeShopLocations())
                .ReturnsAsync(MockObjects.EmptyShopLocations);

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
                .ReturnsAsync(MockObjects.ValidCoffeeShopLocations);

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
                .ReturnsAsync(MockObjects.ValidCoffeeShopLocations);

            var coffeeShopLocationRepository = new CoffeeShopLocationRepository(dataReaderMock.Object);

            // Act
            var locations = await coffeeShopLocationRepository.GetCoffeeShopLocations();

            // Assert
            Assert.Equal(5, locations.Count());
        }
    }
}
