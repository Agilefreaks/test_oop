using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace INeedCoffee.Tests
{
    public class CoffeeShopTests
    {
        [Fact]
        public void CoffeeShopDataCapture_ShouldWork()
        {
            List<CoffeeShop> coffeeShopsList = new List<CoffeeShop>();

            string[] csvFileNameFromTerminalArguments = { " ", " ", "coffee_shops.csv" };

            CoffeeShopDataCapture.Capture(coffeeShopsList, csvFileNameFromTerminalArguments);

            List<string> expectedCoffeeShopsList = new List<string> {
            "Starbucks Sibiu Oituz, 45.7826201, 24.1465759",
            "Starbucks Bucuresti Calea Victoriei, 44.4514467, 26.0827712",
            "Starbucks Vienna, 48.1817174, 16.3798455",
            "Starbucks Sibiu Piata Mare, 45.7973354, 24.1503473",
            "Starbucks Andorra la Vella, 42.5080922, 1.5291981",
            "Starbucks Cluj Iulius Mall, 46.771803, 23.6234979"
            };

            List<string> actualCoffeeShopList = new List<string>();

            foreach (var coffeeShop in coffeeShopsList)
            {
                actualCoffeeShopList.Add($"{coffeeShop.Name}, {coffeeShop.Latitude}, {coffeeShop.Longitude}");
            }

            var actual = string.Join(", ", actualCoffeeShopList);

            var expected = string.Join(", ", expectedCoffeeShopsList);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CoffeeShopDistanceCalculator_ShouldWork()
        {
            UserCoordinates userCoordinates = new UserCoordinates
            {
                Latitude = 45.7838552,

                Longitude = 24.1515281
            };

            List<CoffeeShop> coffeeShopsList = new List<CoffeeShop>() {
                new CoffeeShop(){ Latitude=45.7826201, Longitude=24.1465759},
                new CoffeeShop(){ Latitude=44.4514467, Longitude=26.0827712},
                new CoffeeShop(){ Latitude=48.1817174, Longitude=16.3798455}
            };

            CoffeeShopDistanceCalculator.Calculate(userCoordinates, coffeeShopsList);

            List<string> actualCoffeeShopList = new List<string>();

            foreach (var coffeeShop in coffeeShopsList)
            {
                actualCoffeeShopList.Add($"{MathUtilities.RoundValue(coffeeShop.DistanceToUser, 4)}");
            }

            var actual = string.Join(", ", actualCoffeeShopList);

            var expected = "0.408, 211.9753, 646.8313";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CoffeeShopDistanceSorting_ShouldWork()
        {
            List<CoffeeShop> coffeeShopsList = new List<CoffeeShop>() {
                new CoffeeShop(){ DistanceToUser=211.9753},
                new CoffeeShop(){ DistanceToUser=646.8313},
                new CoffeeShop(){ DistanceToUser=0.408}
            };

            var sortedCoffeeShopsListByDistance = CoffeeShopsDistanceSorting.Sort(coffeeShopsList);

            List<string> actualCoffeeShopList = new List<string>();

            foreach (var sortedCoffeeShopByDistance in sortedCoffeeShopsListByDistance)
            {
                actualCoffeeShopList.Add($"{sortedCoffeeShopByDistance.DistanceToUser}");
            }

            var actual = string.Join(", ", actualCoffeeShopList);

            var expected = "0.408, 211.9753, 646.8313";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CoffeeShopDataCaptureWithInvalidData_ShouldThrowError()
        {
            List<CoffeeShop> coffeeShopsList = new List<CoffeeShop>();

            string[] csvFileNameFromTerminalArguments = { " ", " ", "coffee_shops_with_incorrect_data.csv" };

            Assert.Throws<IndexOutOfRangeException>(() => CoffeeShopDataCapture.Capture(coffeeShopsList, csvFileNameFromTerminalArguments));
        }
    }
}
