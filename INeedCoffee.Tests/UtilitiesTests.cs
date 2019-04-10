using System;
using Xunit;
using INeedCoffee;
using System.Collections.Generic;
using System.IO;

namespace INeedCoffee.Tests
{
    public class UtilitiesTests
    {
        [Theory]
        [InlineData(45.7838552, 24.1515281, 45.7826201, 24.1465759, 0.408)]
        public void CalculateDistanceBetweenTwoLocationsWithHaversine_ShouldWork(double firstLatitude, double firstLongitude, double secondLatitude, double secondLongitude, double expected)
        {

            double actual = MathUtilities.RoundValue(HaversineDistanceCalculator.Calculate(firstLatitude, firstLongitude, secondLatitude, secondLongitude), 3);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3.472642195, 4, 3.4726)]
        public void RoundValue_ShouldWork(double valueToRoundUp, int numberOfDecimalsToRoundUpTo, double expected)
        {
            double actual = MathUtilities.RoundValue(valueToRoundUp, numberOfDecimalsToRoundUpTo);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(45.7838552, 0.8)]
        public void ConvertToRadians_ShouldWork(double angle, double expected)
        {
            double actual = MathUtilities.RoundValue(MathUtilities.ConvertToRadians(angle), 2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CSVFileReader_ShouldWork()
        {
            string[] csvFileNamePath = { " ", " ", "coffee_shops.csv" };

            List<string> actual = CSVFileReader.Read(csvFileNamePath);

            List<string> expected = new List<string> {
            "Starbucks Sibiu Oituz,45.7826201,24.1465759",
            "Starbucks Bucuresti Calea Victoriei,44.4514467,26.0827712",
            "Starbucks Vienna,48.1817174,16.3798455",
            "Starbucks Sibiu Piata Mare,45.7973354,24.1503473",
            "Starbucks Andorra la Vella,42.5080922,1.5291981",
            "Starbucks Cluj Iulius Mall,46.771803,23.6234979"
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CSVFileReaderWithMissingFileName_ShouldThrowError()
        {
            string[] csvFileNamePath = { " ", " ", " " };
            Assert.Throws<FileNotFoundException>(() => CSVFileReader.Read(csvFileNamePath));
        }
    }
}
