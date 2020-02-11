using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Interfaces.Facade;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Service.UnitTests
{
    public class CoffeeShopsDisplayServiceTests
    {
        private readonly Mock<ICoffeeShopDistanceRepository> _coffeeShopDistanceRepositoryMock;
        private readonly Mock<ICoffeeShopsDisplayFacade> _displayFacadeMock;

        public CoffeeShopsDisplayServiceTests()
        {
            _coffeeShopDistanceRepositoryMock = new Mock<ICoffeeShopDistanceRepository>();

            _displayFacadeMock = new Mock<ICoffeeShopsDisplayFacade>();
            _displayFacadeMock.Setup(x => x.CoffeeShopDistanceRepository).Returns(_coffeeShopDistanceRepositoryMock.Object);
        }

        [Fact]
        public async Task TestThat_DisplayCoffeeShops_When_CoffeeShopDistancesIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var coffeeShopsDisplayService = new CoffeeShopsDisplayService(_displayFacadeMock.Object);

            // Act
            async Task Act() => await coffeeShopsDisplayService.DisplayCoffeeShopDistances(MockObjects.NullShopDistances);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_DisplayCoffeeShops_When_CoffeeShopDistancesIsEmpty_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var coffeeShopsDisplayService = new CoffeeShopsDisplayService(_displayFacadeMock.Object);

            // Act
            async Task Act() => await coffeeShopsDisplayService.DisplayCoffeeShopDistances(MockObjects.EmptyShopDistances);

            // Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(Act);
        }

        [Fact]
        public async Task TestThat_DisplayCoffeeShops_When_RepositoryThrowsException_Throws_SameException()
        {
            // Arrange
            var mockException = MockObjects.GenericException;

            _coffeeShopDistanceRepositoryMock
                .Setup(x => x.SetCoffeeShopDistances(It.IsAny<IEnumerable<Distance>>()))
                .Throws(mockException);

            var coffeeShopsDisplayService = new CoffeeShopsDisplayService(_displayFacadeMock.Object);

            // Act
            async Task Act() => await coffeeShopsDisplayService.DisplayCoffeeShopDistances(MockObjects.SelectedShopDistances);

            // Assert
            var exception = await Assert.ThrowsAnyAsync<Exception>(Act);
            Assert.Equal(mockException, exception);
        }

        [Fact]
        public async Task TestThat_DisplayCoffeeShops_When_DistancesListIsValid_Calls_RepositoryOutputMethod_Once()
        {
            // Arrange
            var mockDistances = MockObjects.SelectedShopDistances.ToList();

            var coffeeShopsDisplayService = new CoffeeShopsDisplayService(_displayFacadeMock.Object);

            // Act
            await coffeeShopsDisplayService.DisplayCoffeeShopDistances(mockDistances);

            // Assert
            _coffeeShopDistanceRepositoryMock.Verify(x => x.SetCoffeeShopDistances(mockDistances), Times.Once);
        }
    }
}
