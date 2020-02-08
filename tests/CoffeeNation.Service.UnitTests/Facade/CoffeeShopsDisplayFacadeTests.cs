using System;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Facade;
using Moq;
using Xunit;

namespace CoffeeNation.Service.UnitTests.Facade
{
    public class CoffeeShopsDisplayFacadeTests
    {
        [Fact]
        public void TestThat_Constructor_When_AllServicesRegistered_InitializesProperties_AsExpected()
        {
            // Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock
                .Setup(x => x.GetService(typeof(ICoffeeShopDistanceRepository)))
                .Returns(new Mock<ICoffeeShopDistanceRepository>().Object);

            // Act
            var displayFacade = new CoffeeShopsDisplayFacade(serviceProviderMock.Object);

            // Assert
            Assert.NotNull(displayFacade.CoffeeShopDistanceRepository);
        }
    }
}
