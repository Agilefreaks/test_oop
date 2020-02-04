using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Repository.UnitTests
{
    public class CoffeeShopDistanceRepositoryTests
    {
        [Fact]
        public async Task TestThat_SetCoffeeShopDistances_When_DistancesListIsNull_Throws_ArgumentValidationException()
        {
            // Arrange
            var dataWriterMock = new Mock<ICoffeeShopDistanceDataWriter>();
            
            var coffeeShopDistanceRepository = new CoffeeShopDistanceRepository(dataWriterMock.Object);

            // Act
            async Task Act() => await coffeeShopDistanceRepository.SetCoffeeShopDistances(MockData.NullShopDistances);

            // Assert
            await Assert.ThrowsAsync<ArgumentValidationException>(Act);
        }

        [Fact]
        public async Task TestThat_SetCoffeeShopDistances_When_DistancesListIsEmpty_Throws_ArgumentValidationException()
        {
            // Arrange
            var dataWriterMock = new Mock<ICoffeeShopDistanceDataWriter>();

            var coffeeShopDistanceRepository = new CoffeeShopDistanceRepository(dataWriterMock.Object);

            // Act
            async Task Act() => await coffeeShopDistanceRepository.SetCoffeeShopDistances(MockData.EmptyShopDistances);

            // Assert
            await Assert.ThrowsAsync<ArgumentValidationException>(Act);
        }

        [Fact]
        public async Task TestThat_SetCoffeeShopDistances_When_DataWriterThrowsDataProviderException_Throws_DataProviderException()
        {
            // Arrange
            var dataWriterMock = new Mock<ICoffeeShopDistanceDataWriter>();
            dataWriterMock
                .Setup(x => x.WriteCoffeeShopDistances(It.IsAny<IEnumerable<Distance>>()))
                .Throws<DataProviderException>();

            var coffeeShopDistanceRepository = new CoffeeShopDistanceRepository(dataWriterMock.Object);

            // Act
            async Task Act() => await coffeeShopDistanceRepository.SetCoffeeShopDistances(MockData.SelectedShopDistances);

            // Assert
            await Assert.ThrowsAsync<DataProviderException>(Act);
        }

        [Fact]
        public async Task TestThat_SetCoffeeShopDistances_When_DistancesListIsValid_Calls_DataWriterWriteCoffeeShopDistances_Once()
        {
            // Arrange
            var distancesMock = MockData.SelectedShopDistances.ToList();

            var dataWriterMock = new Mock<ICoffeeShopDistanceDataWriter>();
            dataWriterMock.Setup(x => x.WriteCoffeeShopDistances(It.IsAny<IEnumerable<Distance>>()));

            var coffeeShopDistanceRepository = new CoffeeShopDistanceRepository(dataWriterMock.Object);

            // Act
            await coffeeShopDistanceRepository.SetCoffeeShopDistances(distancesMock);

            // Assert
            dataWriterMock.Verify(x => x.WriteCoffeeShopDistances(distancesMock), Times.Once);
        }
    }
}
