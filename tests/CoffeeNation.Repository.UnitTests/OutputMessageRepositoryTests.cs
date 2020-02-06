using System;
using System.Threading.Tasks;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Repository.UnitTests
{
    public class OutputMessageRepositoryTests
    {
        [Fact]
        public async Task TestThat_SendMessage_When_MessageIsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var dataWriterMock = new Mock<IMessageDataWriter>();

            var outputMessageRepository = new OutputMessageRepository(dataWriterMock.Object);

            // Act
            async Task Act() => await outputMessageRepository.SendMessage(MockData.NullMessage);

            // Assert
            await Assert.ThrowsAsync<ArgumentNullException>(Act);
        }

        [Fact]
        public async Task TestThat_SendMessage_When_DataWriterThrowsException_Throws_SameException()
        {
            // Arrange
            var mockException = MockData.GenericException;

            var dataWriterMock = new Mock<IMessageDataWriter>();
            dataWriterMock
                .Setup(x => x.WriteMessage(It.IsAny<string>()))
                .Throws(mockException);

            var outputMessageRepository = new OutputMessageRepository(dataWriterMock.Object);

            // Act
            async Task Act() => await outputMessageRepository.SendMessage(MockData.ValidMessage);

            // Assert
            var exception = await Assert.ThrowsAnyAsync<Exception>(Act);
            Assert.Equal(mockException, exception);
        }

        [Fact]
        public async Task TestThat_SendMessage_When_MessageIsValid_Calls_DataWriterWriteMessage_Once()
        {
            // Arrange
            var dataWriterMock = new Mock<IMessageDataWriter>();
            
            var outputMessageRepository = new OutputMessageRepository(dataWriterMock.Object);

            var message = MockData.ValidMessage;

            // Act
            await outputMessageRepository.SendMessage(message);

            // Assert
            dataWriterMock.Verify(x => x.WriteMessage(message), Times.Once);
        }
    }
}
