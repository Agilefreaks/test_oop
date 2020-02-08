using System;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces.Parser;
using CoffeeNation.Data.Interfaces.Provider;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Data.UnitTests
{
    public class CsvCoffeeShopLocationDataReaderTests
    {
        [Fact]
        public async Task TestThat_ReadCoffeeShopLocations_When_ParserThrowsDataValidationException_Throws_DataValidationExceptionWithExpectedMessage()
        {
            // Arrange
            var csvContentProviderMock = new Mock<ICsvContentProvider>();
            csvContentProviderMock
                .Setup(x => x.GetCsvLines())
                .ReturnsAsync(MockData.ValidCsvContent);

            var csvContentParserMock = new Mock<ICsvLineParser>();
            csvContentParserMock
                .Setup(x => x.GetCoffeeShopLocation(It.IsAny<string>()))
                .Throws(new DataValidationException(MockValues.CsvDataValidationExceptionMessage));

            var dataReader = new CsvCoffeeShopLocationDataReader(csvContentProviderMock.Object, csvContentParserMock.Object);

            // Act
            async Task Act() => await dataReader.ReadCoffeeShopLocations();

            // Assert
            var exception = await Assert.ThrowsAsync<DataValidationException>(Act);
            Assert.Equal(MockValues.CsvDataValidationExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_ReadCoffeeShopLocations_When_ParserThrowsException_Throws_SameException()
        {
            // Arrange
            var mockException = MockData.GenericException; 

            var csvContentProviderMock = new Mock<ICsvContentProvider>();
            csvContentProviderMock
                .Setup(x => x.GetCsvLines())
                .ReturnsAsync(MockData.ValidCsvContent);

            var csvContentParserMock = new Mock<ICsvLineParser>();
            csvContentParserMock
                .Setup(x => x.GetCoffeeShopLocation(It.IsAny<string>()))
                .Throws(mockException);

            var dataReader = new CsvCoffeeShopLocationDataReader(csvContentProviderMock.Object, csvContentParserMock.Object);

            // Act
            async Task Act() => await dataReader.ReadCoffeeShopLocations();

            // Assert
            var exception = await Assert.ThrowsAnyAsync<Exception>(Act);
            Assert.Equal(mockException, exception);
        }

        [Fact]
        public async Task TestThat_ReadCoffeeShopLocations_When_ProviderThrowsDataProviderException_Throws_DataProviderExceptionWithExpectedMessage()
        {
            // Arrange
            var csvContentProviderMock = new Mock<ICsvContentProvider>();
            csvContentProviderMock.Setup(x => x.GetCsvLines())
                .Throws(new DataProviderException(MockValues.CsvDataProviderExceptionMessage));

            var csvContentParserMock = new Mock<ICsvLineParser>();
            csvContentParserMock
                .Setup(x => x.GetCoffeeShopLocation(It.IsAny<string>()))
                .ReturnsAsync(MockData.ShopLocation1);

            var dataReader = new CsvCoffeeShopLocationDataReader(csvContentProviderMock.Object, csvContentParserMock.Object);

            // Act
            async Task Act() => await dataReader.ReadCoffeeShopLocations();

            // Assert
            var exception = await Assert.ThrowsAsync<DataProviderException>(Act);
            Assert.Equal(MockValues.CsvDataProviderExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_ReadCoffeeShopLocations_When_ProviderThrowsException_Throws_SameException()
        {
            // Arrange
            var mockException = MockData.GenericException;

            var csvContentProviderMock = new Mock<ICsvContentProvider>();
            csvContentProviderMock.Setup(x => x.GetCsvLines())
                .Throws(mockException);

            var csvContentParserMock = new Mock<ICsvLineParser>();
            csvContentParserMock
                .Setup(x => x.GetCoffeeShopLocation(It.IsAny<string>()))
                .ReturnsAsync(MockData.ShopLocation1);

            var dataReader = new CsvCoffeeShopLocationDataReader(csvContentProviderMock.Object, csvContentParserMock.Object);

            // Act
            async Task Act() => await dataReader.ReadCoffeeShopLocations();

            // Assert
            var exception = await Assert.ThrowsAnyAsync<Exception>(Act);
            Assert.Equal(mockException, exception);
        }

        [Fact]
        public async Task TestThat_ReadCoffeeShopLocations_When_ParserAndProviderDoNotThrowExceptions_Returns_NotNullLocation()
        {
            // Arrange
            var csvContentProviderMock = new Mock<ICsvContentProvider>();
            csvContentProviderMock
                .Setup(x => x.GetCsvLines())
                .ReturnsAsync(MockData.ValidCsvContent);

            var csvContentParserMock = new Mock<ICsvLineParser>();
            csvContentParserMock
                .Setup(x => x.GetCoffeeShopLocation(It.IsAny<string>()))
                .ReturnsAsync(MockData.ShopLocation1);

            var dataReader = new CsvCoffeeShopLocationDataReader(csvContentProviderMock.Object, csvContentParserMock.Object);

            // Act
            var locations = await dataReader.ReadCoffeeShopLocations();

            // Assert
            Assert.NotNull(locations);
        }

        [Fact]
        public async Task TestThat_ReadCoffeeShopLocations_When_ParserAndProviderDoNotThrowExceptions_Returns_LocationWithExpectedValues()
        {
            // Arrange
            var csvContentMock = MockData.ValidCsvContent.ToList();

            var csvContentProviderMock = new Mock<ICsvContentProvider>();
            csvContentProviderMock
                .Setup(x => x.GetCsvLines())
                .ReturnsAsync(csvContentMock);

            var csvContentParserMock = new Mock<ICsvLineParser>();
            csvContentParserMock
                .Setup(x => x.GetCoffeeShopLocation(It.IsAny<string>()))
                .ReturnsAsync(MockData.ShopLocation1);

            var dataReader = new CsvCoffeeShopLocationDataReader(csvContentProviderMock.Object, csvContentParserMock.Object);

            // Act
            var locations = await dataReader.ReadCoffeeShopLocations();

            // Assert
            Assert.Equal(csvContentMock.Count, locations.Count());
        }
    }
}
