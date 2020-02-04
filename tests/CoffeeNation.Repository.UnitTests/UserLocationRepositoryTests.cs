using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Repository.UnitTests
{
    public class UserLocationRepositoryTests
    {
        [Fact]
        public async Task TestThat_GetUserLocation_When_DataReaderThrowsDataValidationException_Throws_DataValidationException()
        {
            // Arrange
            var dataReaderMock = new Mock<IUserLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadUserLocation())
                .Throws<DataValidationException>();

            var userLocationRepository = new UserLocationRepository(dataReaderMock.Object);

            // Act
            async Task Act() => await userLocationRepository.GetUserLocation();

            // Assert
            await Assert.ThrowsAsync<DataValidationException>(Act);
        }

        [Fact]
        public async Task TestThat_GetUserLocation_When_DataReaderThrowsDataProviderException_Throws_DataProviderException()
        {
            // Arrange
            var dataReaderMock = new Mock<IUserLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadUserLocation())
                .Throws<DataProviderException>();

            var userLocationRepository = new UserLocationRepository(dataReaderMock.Object);

            // Act
            async Task Act() => await userLocationRepository.GetUserLocation();

            // Assert
            await Assert.ThrowsAsync<DataProviderException>(Act);
        }

        [Fact]
        public async Task TestThat_GetUserLocation_When_DataReaderReturnsItems_Returns_NotNullLocation()
        {
            // Arrange
            var dataReaderMock = new Mock<IUserLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadUserLocation())
                .ReturnsAsync(MockData.UserLocation1);

            var userLocationRepository = new UserLocationRepository(dataReaderMock.Object);

            // Act
            var location = await userLocationRepository.GetUserLocation();

            // Assert
            Assert.NotNull(location);
        }

        [Fact]
        public async Task TestThat_GetUserLocation_When_DataReaderReturnsItems_Returns_LocationWithExpectedValues()
        {
            // Arrange
            var mockLocation = MockData.UserLocation1;

            var dataReaderMock = new Mock<IUserLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadUserLocation())
                .ReturnsAsync(mockLocation);

            var userLocationRepository = new UserLocationRepository(dataReaderMock.Object);

            // Act
            var location = await userLocationRepository.GetUserLocation();

            // Assert
            Assert.Equal(mockLocation.X, location.X);
            Assert.Equal(mockLocation.Y, location.Y);
            Assert.Equal(mockLocation.Tag, location.Tag);
        }
    }
}