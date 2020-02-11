using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Core.Interfaces;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Interfaces.Facade;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Service.UnitTests
{
    public class CoffeeShopsQueryServiceTests
    {
        private readonly Mock<IUserLocationRepository> _userLocationRepositoryMock;
        private readonly Mock<ICoffeeShopLocationRepository> _coffeeShopLocationRepositoryMock;
        private readonly Mock<IDistanceCalculator> _distanceCalculatorMock;
        private readonly Mock<IDistanceSelector> _distanceSelectorMock;

        private readonly Mock<ICoffeeShopsQueryFacade> _queryFacadeMock;

        public CoffeeShopsQueryServiceTests()
        {
            _userLocationRepositoryMock = new Mock<IUserLocationRepository>();
            _coffeeShopLocationRepositoryMock = new Mock<ICoffeeShopLocationRepository>();
            _distanceCalculatorMock = new Mock<IDistanceCalculator>();
            _distanceSelectorMock = new Mock<IDistanceSelector>();

            _queryFacadeMock = new Mock<ICoffeeShopsQueryFacade>();
            _queryFacadeMock.Setup(x => x.UserLocationRepository)
                .Returns(_userLocationRepositoryMock.Object);
            _queryFacadeMock.Setup(x => x.CoffeeShopLocationRepository)
                .Returns(_coffeeShopLocationRepositoryMock.Object);
            _queryFacadeMock.Setup(x => x.DistanceCalculator)
                .Returns(_distanceCalculatorMock.Object);
            _queryFacadeMock.Setup(x => x.DistanceSelector)
                .Returns(_distanceSelectorMock.Object);
        }

        [Fact]
        public async Task TestThat_GetShortestCoffeeShopDistances_When_DistanceCalculatorThrowsArgumentNullException_Throws_ArgumentNullException()
        {
            // Arrange
            _userLocationRepositoryMock
                .Setup(x => x.GetUserLocation())
                .ReturnsAsync(MockObjects.UserLocation1);

            _coffeeShopLocationRepositoryMock
                .Setup(x => x.GetCoffeeShopLocations())
                .ReturnsAsync(MockObjects.ValidCoffeeShopLocations);

            _distanceCalculatorMock
                .Setup(x => x.CalculateDistanceToDestination(It.IsAny<Location>(), It.IsAny<Location>()))
                .Throws<ArgumentNullException>();

            var coffeeShopsQueryService = new CoffeeShopsQueryService(_queryFacadeMock.Object);

            // Act
            async Task Act() => await coffeeShopsQueryService.GetShortestCoffeeShopDistances();

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_GetShortestCoffeeShopDistances_When_DistanceSelectorThrowsArgumentNullException_Throws_ArgumentNullException()
        {
            // Arrange
            _distanceSelectorMock
                .Setup(x => x.SelectDistances(It.IsAny<IEnumerable<Distance>>()))
                .Throws<ArgumentNullException>();

            var coffeeShopsQueryService = new CoffeeShopsQueryService(_queryFacadeMock.Object);

            // Act
            async Task Act() => await coffeeShopsQueryService.GetShortestCoffeeShopDistances();

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_GetShortestCoffeeShopDistances_When_DistanceSelectorThrowsArgumentOutOfRangeException_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            _distanceSelectorMock
                .Setup(x => x.SelectDistances(It.IsAny<IEnumerable<Distance>>()))
                .Throws<ArgumentOutOfRangeException>();

            var coffeeShopsQueryService = new CoffeeShopsQueryService(_queryFacadeMock.Object);

            // Act
            async Task Act() => await coffeeShopsQueryService.GetShortestCoffeeShopDistances();

            // Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(Act);
        }

        [Fact]
        public async Task TestThat_GetShortestCoffeeShopDistances_When_UserLocationRepositoryThrowsDataValidationException_Throws_DataValidationExceptionWithExpectedMessage()
        {
            // Arrange
            _userLocationRepositoryMock
                .Setup(x => x.GetUserLocation())
                .Throws(new DataValidationException(MockValues.CommandLineDataValidationExceptionMessage));

            var coffeeShopsQueryService = new CoffeeShopsQueryService(_queryFacadeMock.Object);

            // Act
            async Task Act() => await coffeeShopsQueryService.GetShortestCoffeeShopDistances();

            // Assert
            var exception = await Assert.ThrowsAsync<DataValidationException>(Act);
            Assert.Equal(MockValues.CommandLineDataValidationExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_GetShortestCoffeeShopDistances_When_CoffeeShopLocationRepositoryThrowsDataValidationException_Throws_DataValidationExceptionWithExpectedMessage()
        {
            // Arrange
            _coffeeShopLocationRepositoryMock
                .Setup(x => x.GetCoffeeShopLocations())
                .Throws(new DataValidationException(MockValues.CsvDataValidationExceptionMessage));

            var coffeeShopsQueryService = new CoffeeShopsQueryService(_queryFacadeMock.Object);

            // Act
            async Task Act() => await coffeeShopsQueryService.GetShortestCoffeeShopDistances();

            // Assert
            var exception = await Assert.ThrowsAsync<DataValidationException>(Act);
            Assert.Equal(MockValues.CsvDataValidationExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_GetShortestCoffeeShopDistances_When_NoExceptionThrown_Returns_NotNullDistanceList()
        {
            // Arrange
            _userLocationRepositoryMock
                .Setup(x => x.GetUserLocation())
                .ReturnsAsync(MockObjects.UserLocation1);

            _coffeeShopLocationRepositoryMock
                .Setup(x => x.GetCoffeeShopLocations())
                .ReturnsAsync(MockObjects.ValidCoffeeShopLocations);

            _distanceCalculatorMock
                .Setup(x => x.CalculateDistanceToDestination(It.IsAny<Location>(), It.IsAny<Location>()))
                .ReturnsAsync(MockObjects.ShopDistance1);

            _distanceSelectorMock
                .Setup(x => x.SelectDistances(It.IsAny<IEnumerable<Distance>>()))
                .ReturnsAsync(MockObjects.SelectedShopDistances);

            var coffeeShopsQueryService = new CoffeeShopsQueryService(_queryFacadeMock.Object);

            // Act
            var distances = await coffeeShopsQueryService.GetShortestCoffeeShopDistances();

            // Assert
            Assert.NotNull(distances);
        }

        [Fact]
        public async Task TestThat_GetShortestCoffeeShopDistances_When_NoExceptionThrown_Returns_ExpectedElementsCount()
        {
            // Arrange
            _userLocationRepositoryMock
                .Setup(x => x.GetUserLocation())
                .ReturnsAsync(MockObjects.UserLocation1);

            _coffeeShopLocationRepositoryMock
                .Setup(x => x.GetCoffeeShopLocations())
                .ReturnsAsync(MockObjects.ValidCoffeeShopLocations);

            _distanceCalculatorMock
                .Setup(x => x.CalculateDistanceToDestination(It.IsAny<Location>(), It.IsAny<Location>()))
                .ReturnsAsync(MockObjects.ShopDistance1);

            _distanceSelectorMock
                .Setup(x => x.SelectDistances(It.IsAny<IEnumerable<Distance>>()))
                .ReturnsAsync(MockObjects.SelectedShopDistances);

            var coffeeShopsQueryService = new CoffeeShopsQueryService(_queryFacadeMock.Object);

            // Act
            var distances = await coffeeShopsQueryService.GetShortestCoffeeShopDistances();

            // Assert
            Assert.Equal(MockValues.DefaultOutputDistancesCount, distances.Count());
        }
    }
}
