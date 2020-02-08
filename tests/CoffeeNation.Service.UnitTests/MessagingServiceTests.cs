using System;
using System.Threading.Tasks;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Service.UnitTests
{
    public class MessagingServiceTests
    {
        [Fact]
        public async Task TestThat_SendErrorDetails_When_MessageIsNull_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var messagingService = new MessagingService(outputMessageRepositoryMock.Object);

            // Act
            async Task Act() => await messagingService.SendErrorDetails(MockData.NullMessage, MockData.GenericException);

            // Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(Act);
        }

        [Fact]
        public async Task TestThat_SendErrorDetails_When_MessageIsEmpty_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var messagingService = new MessagingService(outputMessageRepositoryMock.Object);

            // Act
            async Task Act() => await messagingService.SendErrorDetails(MockData.EmptyMessage, MockData.GenericException);

            // Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(Act);
        }

        [Fact]
        public async Task TestThat_SendErrorDetails_When_ExceptionIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var messagingService = new MessagingService(outputMessageRepositoryMock.Object);

            // Act
            async Task Act() => await messagingService.SendErrorDetails(MockData.ValidMessage, MockData.NullException);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_SendErrorDetails_When_OutputRepositoryThrowsException_Throws_SameException()
        {
            // Arrange
            var mockException = MockData.GenericException;

            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();
            outputMessageRepositoryMock
                .Setup(x => x.SendMessage(It.IsAny<string>()))
                .Throws(mockException);

            var messagingService = new MessagingService(outputMessageRepositoryMock.Object);

            // Act
            async Task Act() => await messagingService.SendErrorDetails(MockData.ValidMessage, MockData.GenericException);

            // Assert
            var exception = await Assert.ThrowsAnyAsync<Exception>(Act);
            Assert.Equal(mockException, exception);
        }

        [Fact]
        public async Task TestThat_SendErrorDetails_When_ArgumentsAreValid_Calls_OutputRepoSendMessageMethodWithCorrectArgument_Once()
        {
            // Arrange
            var outputMessageRepositoryMock = new Mock<IOutputMessageRepository>();

            var messagingService = new MessagingService(outputMessageRepositoryMock.Object);

            // Act
            await messagingService.SendErrorDetails(MockData.ValidErrorDetailsMessage, MockData.GenericException);

            // Assert
            outputMessageRepositoryMock.Verify(x => x.SendMessage(MockData.ValidErrorDetailsString), Times.Once);
        }
    }
}
