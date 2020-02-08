using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Service.Interfaces;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.ConsoleApp.UnitTests
{
    public class ApplicationTests
    {
        private readonly Mock<ICoffeeShopsQueryService> _queryServiceMock;
        private readonly Mock<ICoffeeShopsDisplayService> _displayServiceMock;
        private readonly Mock<IMessagingService> _messagingServiceMock;

        private readonly Mock<IServiceProvider> _serviceProviderMock;

        public ApplicationTests()
        {
            _queryServiceMock = new Mock<ICoffeeShopsQueryService>();
            _displayServiceMock = new Mock<ICoffeeShopsDisplayService>();
            _messagingServiceMock = new Mock<IMessagingService>();

            _serviceProviderMock = new Mock<IServiceProvider>();
            _serviceProviderMock
                .Setup(x => x.GetService(typeof(ICoffeeShopsQueryService)))
                .Returns(_queryServiceMock.Object);
            _serviceProviderMock
                .Setup(x => x.GetService(typeof(ICoffeeShopsDisplayService)))
                .Returns(_displayServiceMock.Object);
            _serviceProviderMock
                .Setup(x => x.GetService(typeof(IMessagingService)))
                .Returns(_messagingServiceMock.Object);
        }

        [Fact]
        public async Task TestThat_DisplayClosestCoffeeShops_When_QueryServiceThrows_DataValidationException_Calls_MessagingServiceWithCorrectParameters_Once()
        {
            // Arrange
            var mockException = MockData.DataValidationException;

            _queryServiceMock
                .Setup(x => x.GetClosestCoffeeShops())
                .Throws(mockException);

            var application = new Application(_serviceProviderMock.Object);

            // Act
            await application.DisplayClosestCoffeeShops();

            // Assert
            _messagingServiceMock.Verify(x => x.SendErrorDetails(MockValues.DataValidationExceptionApplicationMessage, mockException), Times.Once);
        }

        [Fact]
        public async Task TestThat_DisplayClosestCoffeeShops_When_QueryServiceThrows_DataProviderException_Calls_MessagingServiceWithCorrectParameters_Once()
        {
            // Arrange
            var mockException = MockData.DataProviderException;

            _queryServiceMock
                .Setup(x => x.GetClosestCoffeeShops())
                .Throws(mockException);

            var application = new Application(_serviceProviderMock.Object);

            // Act
            await application.DisplayClosestCoffeeShops();

            // Assert
            _messagingServiceMock.Verify(x => x.SendErrorDetails(MockValues.DataProviderExceptionApplicationMessage, mockException), Times.Once);
        }

        [Fact]
        public async Task TestThat_DisplayClosestCoffeeShops_When_QueryServiceThrows_GenericException_Calls_MessagingServiceWithCorrectParameters_Once()
        {
            // Arrange
            var mockException = MockData.GenericException;

            _queryServiceMock
                .Setup(x => x.GetClosestCoffeeShops())
                .Throws(mockException);

            var application = new Application(_serviceProviderMock.Object);

            // Act
            await application.DisplayClosestCoffeeShops();

            // Assert
            _messagingServiceMock.Verify(x => x.SendErrorDetails(MockValues.GenericExceptionApplicationMessage, mockException), Times.Once);
        }

        [Fact]
        public async Task TestThat_DisplayClosestCoffeeShops_When_DisplayServiceThrows_DataValidationException_Calls_MessagingServiceWithCorrectParameters_Once()
        {
            // Arrange
            var mockException = MockData.DataValidationException;

            _displayServiceMock
                .Setup(x => x.DisplayCoffeeShopDistances(It.IsAny<IEnumerable<Distance>>()))
                .Throws(mockException);

            var application = new Application(_serviceProviderMock.Object);

            // Act
            await application.DisplayClosestCoffeeShops();

            // Assert
            _messagingServiceMock.Verify(x => x.SendErrorDetails(MockValues.DataValidationExceptionApplicationMessage, mockException), Times.Once);
        }

        [Fact]
        public async Task TestThat_DisplayClosestCoffeeShops_When_DisplayServiceThrows_DataProviderException_Calls_MessagingServiceWithCorrectParameters_Once()
        {
            // Arrange
            var mockException = MockData.DataProviderException;

            _displayServiceMock
                .Setup(x => x.DisplayCoffeeShopDistances(It.IsAny<IEnumerable<Distance>>()))
                .Throws(mockException);

            var application = new Application(_serviceProviderMock.Object);

            // Act
            await application.DisplayClosestCoffeeShops();

            // Assert
            _messagingServiceMock.Verify(x => x.SendErrorDetails(MockValues.DataProviderExceptionApplicationMessage, mockException), Times.Once);
        }

        [Fact]
        public async Task TestThat_DisplayClosestCoffeeShops_When_DisplayServiceThrows_GenericException_Calls_MessagingServiceWithCorrectParameters_Once()
        {
            // Arrange
            var mockException = MockData.GenericException;

            _displayServiceMock
                .Setup(x => x.DisplayCoffeeShopDistances(It.IsAny<IEnumerable<Distance>>()))
                .Throws(mockException);

            var application = new Application(_serviceProviderMock.Object);

            // Act
            await application.DisplayClosestCoffeeShops();

            // Assert
            _messagingServiceMock.Verify(x => x.SendErrorDetails(MockValues.GenericExceptionApplicationMessage, mockException), Times.Once);
        }

        [Fact]
        public async Task TestThat_DisplayClosestCoffeeShops_When_NoError_Calls_QueryService_Once()
        {
            // Arrange
            _queryServiceMock
                .Setup(x => x.GetClosestCoffeeShops())
                .ReturnsAsync(MockData.SelectedShopDistances);

            _displayServiceMock
                .Setup(x => x.DisplayCoffeeShopDistances(It.IsAny<IEnumerable<Distance>>()));

            var application = new Application(_serviceProviderMock.Object);

            // Act
            await application.DisplayClosestCoffeeShops();

            // Assert
            _queryServiceMock.Verify(x => x.GetClosestCoffeeShops(), Times.Once);
        }

        [Fact]
        public async Task TestThat_DisplayClosestCoffeeShops_When_NoError_Calls_DisplayService_Once()
        {
            // Arrange
            var mockDistances = MockData.SelectedShopDistances.ToList();

            _queryServiceMock
                .Setup(x => x.GetClosestCoffeeShops())
                .ReturnsAsync(mockDistances);

            _displayServiceMock
                .Setup(x => x.DisplayCoffeeShopDistances(It.IsAny<IEnumerable<Distance>>()));

            var application = new Application(_serviceProviderMock.Object);

            // Act
            await application.DisplayClosestCoffeeShops();

            // Assert
            _displayServiceMock.Verify(x => x.DisplayCoffeeShopDistances(mockDistances), Times.Once);
        }
    }
}
