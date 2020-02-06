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
        public async Task TestThat_GetUserLocation_When_DataReaderThrowsDataValidationException_Throws_DataValidationExceptionWithExpectedMessage()
        {
            // Arrange
            var dataReaderMock = new Mock<IUserLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadUserLocation())
                .Throws(new DataValidationException(MockValues.CommandLineDataValidationExceptionMessage));

            var userLocationRepository = new UserLocationRepository(dataReaderMock.Object);

            // Act
            async Task Act() => await userLocationRepository.GetUserLocation();

            // Assert
            var exception = await Assert.ThrowsAsync<DataValidationException>(Act);
            Assert.Equal(MockValues.CommandLineDataValidationExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_GetUserLocation_When_DataReaderThrowsDataProviderException_Throws_DataProviderExceptionWithExpectedMessage()
        {
            // Arrange
            var dataReaderMock = new Mock<IUserLocationDataReader>();
            dataReaderMock
                .Setup(x => x.ReadUserLocation())
                .Throws(new DataProviderException(MockValues.UserLocationDataProviderExceptionMessage));

            var userLocationRepository = new UserLocationRepository(dataReaderMock.Object);

            // Act
            async Task Act() => await userLocationRepository.GetUserLocation();

            // Assert
            var exception = await Assert.ThrowsAsync<DataProviderException>(Act);
            Assert.Equal(MockValues.UserLocationDataProviderExceptionMessage, exception.Message);
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