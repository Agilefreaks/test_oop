using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Parser;
using CoffeeNation.UnitTestsCommon;
using Moq;
using Xunit;

namespace CoffeeNation.Data.UnitTests.Parser
{
    public class CsvLineParserTests
    {
        [Fact]
        public async Task TestThat_GetCoffeeShopLocation_When_CsvLineIsNull_Throws_DataValidationExceptionWithExpectedMessage()
        {
            // Arrange
            var csvLineParser = new CsvLineParser();

            // Act
            async Task Act() => await csvLineParser.GetCoffeeShopLocation(MockData.StringNullCsvLine);

            // Assert
            var exception = await Assert.ThrowsAsync<DataValidationException>(Act);
            Assert.Equal(MockValues.NullOrEmptyCsvLineExceptionMessage, exception.Message);
        }

        [Fact]
        public async Task TestThat_GetCoffeeShopLocation_When_CsvLineIsEmpty_Throws_DataValidationExceptionWithExpectedMessage()
        {
            // Arrange
            var csvLineParser = new CsvLineParser();

            // Act
            async Task Act() => await csvLineParser.GetCoffeeShopLocation(MockData.StringNullCsvLine);

            // Assert
            var exception = await Assert.ThrowsAsync<DataValidationException>(Act);
            Assert.Equal(MockValues.NullOrEmptyCsvLineExceptionMessage, exception.Message);
        }

        // TODO: Add tests for the rest of validation scenarios

        [Fact]
        public async Task TestThat_GetCoffeeShopLocation_When_ValidationDoesNotFail_Returns_NotNullLocation()
        {
            // Arrange
            var csvLineParser = new CsvLineParser();

            // Act
            var location = await csvLineParser.GetCoffeeShopLocation(MockData.ValidCsvLine1);

            // Assert
            Assert.NotNull(location);
        }

        [Fact]
        public async Task TestThat_GetCoffeeShopLocation_When_ValidatorDoesNotFail_Returns_LocationWithExpectedValues()
        {
            var csvLineParser = new CsvLineParser();

            // Act
            var location = await csvLineParser.GetCoffeeShopLocation(MockData.ValidCsvLine99);

            // Assert
            Assert.Equal(MockData.ShopLocation99.X, location.X);
            Assert.Equal(MockData.ShopLocation99.Y, location.Y);
            Assert.Equal(MockData.ShopLocation99.Tag, location.Tag);
        }
    }
}
