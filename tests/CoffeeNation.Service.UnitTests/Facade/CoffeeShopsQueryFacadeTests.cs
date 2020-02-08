using System;
using CoffeeNation.Core.Interfaces;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Facade;
using Moq;
using Xunit;

namespace CoffeeNation.Service.UnitTests.Facade
{
    public class CoffeeShopsQueryFacadeTests
    {
        [Fact]
        public void TestThat_Constructor_When_AllServicesRegistered_InitializesProperties_AsExpected()
        {
            // Arrange
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock
                .Setup(x => x.GetService(typeof(ICoffeeShopLocationRepository)))
                .Returns(new Mock<ICoffeeShopLocationRepository>().Object);
            serviceProviderMock
                .Setup(x => x.GetService(typeof(IUserLocationRepository)))
                .Returns(new Mock<IUserLocationRepository>().Object);
            serviceProviderMock
                .Setup(x => x.GetService(typeof(IDistanceCalculator)))
                .Returns(new Mock<IDistanceCalculator>().Object);
            serviceProviderMock
                .Setup(x => x.GetService(typeof(IDistanceSelector)))
                .Returns(new Mock<IDistanceSelector>().Object);

            // Act
            var queryFacade = new CoffeeShopsQueryFacade(serviceProviderMock.Object);

            // Assert
            Assert.NotNull(queryFacade.CoffeeShopLocationRepository);
            Assert.NotNull(queryFacade.UserLocationRepository);
            Assert.NotNull(queryFacade.DistanceCalculator);
            Assert.NotNull(queryFacade.DistanceSelector);
        }
    }
}
