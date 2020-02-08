using System;
using System.Threading.Tasks;
using CoffeeNation.Data.Interfaces.Provider;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Data.UnitTests
{
    public class ConsoleMessageDataWriterTests
    {
        [Fact]
        public async Task TestThat_WriteMessage_When_MessageIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var outputProviderMock = new Mock<IConsoleOutputProvider>();

            var dataWriter = new ConsoleMessageDataWriter(outputProviderMock.Object);

            // Act
            async Task Act() => await dataWriter.WriteMessage(MockData.NullMessage);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_WriteMessage_When_OutputProviderThrowsException_Throws_SameException()
        {
            // Arrange
            var mockException = MockData.GenericException;

            var outputProviderMock = new Mock<IConsoleOutputProvider>();
            outputProviderMock
                .Setup(x => x.OutputStringLine(It.IsAny<string>()))
                .Throws(mockException);

            var dataWriter = new ConsoleMessageDataWriter(outputProviderMock.Object);

            // Act
            async Task Act() => await dataWriter.WriteMessage(MockData.ValidMessage);

            // Assert
            var exception = await Assert.ThrowsAnyAsync<Exception>(Act);
            Assert.Equal(mockException, exception);
        }

        [Fact]
        public async Task TestThat_WriteMessage_When_MessageIsValid_Calls_OutputProviderOutputMethod_Once()
        {
            // Arrange
            var outputProviderMock = new Mock<IConsoleOutputProvider>();

            var mockMessage = MockData.ValidMessage;

            var dataWriter = new ConsoleMessageDataWriter(outputProviderMock.Object);

            // Act
            await dataWriter.WriteMessage(mockMessage);

            // Assert
            outputProviderMock.Verify(x => x.OutputStringLine(mockMessage), Times.Once);
        }
    }
}
