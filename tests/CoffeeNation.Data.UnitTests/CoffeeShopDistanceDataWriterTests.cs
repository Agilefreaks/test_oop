using System;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Data.Interfaces.Formatter;
using CoffeeNation.Data.Interfaces.Provider;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Data.UnitTests
{
    public class CoffeeShopDistanceDataWriterTests
    {
        [Fact]
        public async Task TestThat_WriteCoffeeShopDistances_When_CoffeeShopDistancesIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var distanceFormatterMock = new Mock<ICoffeeShopDistanceFormatter>();
            var outputProviderMock = new Mock<IConsoleOutputProvider>();

            var dataWriter = new CoffeeShopDistanceDataWriter(distanceFormatterMock.Object, outputProviderMock.Object);

            // Act
            async Task Act() => await dataWriter.WriteCoffeeShopDistances(MockObjects.NullShopDistances);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_WriteCoffeeShopDistances_When_DistanceFormatterThrowsException_Throws_SameException()
        {
            // Arrange
            var mockException = MockObjects.GenericException;

            var distanceFormatterMock = new Mock<ICoffeeShopDistanceFormatter>();
            distanceFormatterMock
                .Setup(x => x.GetFormattedDistance(It.IsAny<Distance>()))
                .Throws(mockException);

            var outputProviderMock = new Mock<IConsoleOutputProvider>();

            var dataWriter = new CoffeeShopDistanceDataWriter(distanceFormatterMock.Object, outputProviderMock.Object);

            // Act
            async Task Act() => await dataWriter.WriteCoffeeShopDistances(MockObjects.AllShopDistances);

            // Assert
            var exception = await Assert.ThrowsAnyAsync<Exception>(Act);
            Assert.Equal(mockException, exception);
        }

        [Fact]
        public async Task TestThat_WriteCoffeeShopDistances_When_OutputProviderThrowsException_Throws_SameException()
        {
            // Arrange
            var mockException = MockObjects.GenericException;

            var distanceFormatterMock = new Mock<ICoffeeShopDistanceFormatter>();

            var outputProviderMock = new Mock<IConsoleOutputProvider>();
            outputProviderMock
                .Setup(x => x.OutputStringLine(It.IsAny<string>()))
                .Throws(mockException);

            var dataWriter = new CoffeeShopDistanceDataWriter(distanceFormatterMock.Object, outputProviderMock.Object);

            // Act
            async Task Act() => await dataWriter.WriteCoffeeShopDistances(MockObjects.AllShopDistances);

            // Assert
            var exception = await Assert.ThrowsAnyAsync<Exception>(Act);
            Assert.Equal(mockException, exception);
        }

        [Fact]
        public async Task TestThat_WriteCoffeeShopDistances_When_DistanceListIsValid_Calls_DistanceFormatterFormattingMethod_ExpectedNumberOfTimes()
        {
            // Arrange
            var distanceFormatterMock = new Mock<ICoffeeShopDistanceFormatter>();

            var outputProviderMock = new Mock<IConsoleOutputProvider>();

            var dataWriter = new CoffeeShopDistanceDataWriter(distanceFormatterMock.Object, outputProviderMock.Object);

            // Act
            await dataWriter.WriteCoffeeShopDistances(MockObjects.AllShopDistances);

            // Assert
            distanceFormatterMock.Verify(
                x => x.GetFormattedDistance(It.IsAny<Distance>()), Times.Exactly(MockObjects.AllShopDistances.Count()));
        }

        [Fact]
        public async Task TestThat_WriteCoffeeShopDistances_When_DistanceListIsValid_Calls_OutputProviderOutputMethod_ExpectedNumberOfTimes()
        {
            // Arrange
            var distanceFormatterMock = new Mock<ICoffeeShopDistanceFormatter>();

            var outputProviderMock = new Mock<IConsoleOutputProvider>();

            var dataWriter = new CoffeeShopDistanceDataWriter(distanceFormatterMock.Object, outputProviderMock.Object);

            // Act
            await dataWriter.WriteCoffeeShopDistances(MockObjects.AllShopDistances);

            // Assert
            outputProviderMock.Verify(
                x => x.OutputStringLine(It.IsAny<string>()), Times.Exactly(MockObjects.AllShopDistances.Count()));
        }
    }
}
