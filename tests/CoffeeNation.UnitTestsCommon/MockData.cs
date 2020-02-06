using System.Collections.Generic;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Exceptions;

namespace CoffeeNation.UnitTestsCommon
{
    public static class MockData
    {
        // Location
        public static Location NullShopLocation => null;

        public static Location ShopLocation1 => new Location
        {
            Tag = "CoffeeShop1",
            X = 0.001,
            Y = -123.7
        };

        public static Location ShopLocation2 => new Location
        {
            Tag = "CoffeeShop2",
            X = -531.2342,
            Y = 45.654654
        };

        public static Location ShopLocation3 => new Location
        {
            Tag = "CoffeeShop3",
            X = 5.0231,
            Y = 654.7
        };

        public static Location ShopLocation4 => new Location
        {
            Tag = "CoffeeShop4",
            X = 345.0231,
            Y = 23.7
        };

        public static Location ShopLocation5 => new Location
        {
            Tag = "CoffeeShop5",
            X = -87.0231,
            Y = 236.7
        };

        public static Location ShopLocation99 => new Location
        {
            Tag = "Starbucks Seattle",
            X = 47.5809,
            Y = -122.3160
        };

        public static IEnumerable<Location> EmptyShopLocations => new List<Location>();

        public static IEnumerable<Location> ValidCoffeeShopLocations => new List<Location>
        {
            ShopLocation1,
            ShopLocation2,
            ShopLocation3,
            ShopLocation4,
            ShopLocation5
        };

        public static Location NullUserLocation => null;

        public static Location UserLocation1 => new Location
        {
            Tag = "User",
            X = -74.546,
            Y = -346.7654
        };

        public static Location UserLocation99 => new Location
        {
            Tag = "User",
            X = 47.6,
            Y = -122.4
        };



        // Distance

        public static Distance NullShopDistance => null;

        public static Distance ShopDistance1 => new Distance
        {
            Tag = "CoffeeShop1",
            Value = 423.21343245
        };

        public static Distance ShopDistance2 => new Distance
        {
            Tag = "CoffeeShop2",
            Value = 56.234568
        };

        public static Distance ShopDistance3 => new Distance
        {
            Tag = "CoffeeShop3",
            Value = 24.5248765
        };

        public static Distance ShopDistance4 => new Distance
        {
            Tag = "CoffeeShop4",
            Value = 5.325
        };

        public static Distance ShopDistance5 => new Distance
        {
            Tag = "CoffeeShop5",
            Value = 7.86535
        };

        public static Distance ShopDistance99 => new Distance
        {
            Tag = "Starbucks Seattle2",
            Value = 0.0645
        };

        public static IEnumerable<Distance> NullShopDistances => null;

        public static IEnumerable<Distance> EmptyShopDistances => new List<Distance>();

        public static IEnumerable<Distance> LessThanThreeShopDistances => new List<Distance>
        {
            ShopDistance1,
            ShopDistance2
        };

        public static IEnumerable<Distance> AllShopDistances => new List<Distance>
        {
            ShopDistance1,
            ShopDistance2,
            ShopDistance3,
            ShopDistance4,
            ShopDistance5
        };

        public static IEnumerable<Distance> SelectedShopDistances => new List<Distance>
        {
            ShopDistance4,
            ShopDistance5,
            ShopDistance3
        };

        // Csv content
        public static string StringNullCsvLine => null;
        public static string StringEmptyCsvLine => null;
        public static string LessThanThreeTokensCsvLine => "Starbucks Seattle,47.5809";
        public static string MoreThanThreeTokensCsvLine => "Starbucks Seattle,47.5809,-122.3160,asd";
        public static string Token1ErrorCsvLine => ",47.5809,-122.3160";
        public static string Token2ErrorCsvLine => "Starbucks Seattle,asd,-122.3160";
        public static string Token3ErrorCsvLine => "Starbucks Seattle,47.5809,qwe";

        public static string ValidCsvLine1 => "Starbucks Seattle,47.5809,-122.3160";
        public static string ValidCsvLine2 => "Starbucks SF,37.5209,-122.3340";
        public static string ValidCsvLine3 => "Starbucks Moscow,55.752047,37.595242";

        public static string ValidCsvLine99 => "Starbucks Seattle,47.5809,-122.3160";

        public static IEnumerable<string> ValidCsvContent => new List<string>
        {
            ValidCsvLine1,
            ValidCsvLine2,
            ValidCsvLine3
        };

        // Command Line Arguments
        public static IEnumerable<string> NullCommandLineArguments => null;
        public static (double, double) ValidRawUserLocation1 => (47.6, -122.4);
        public static (double, double) ValidRawUserLocation99 => (47.6, -122.4);
    }
}
