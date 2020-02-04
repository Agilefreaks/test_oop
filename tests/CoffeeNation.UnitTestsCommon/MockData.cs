using System.Collections.Generic;
using CoffeeNation.Core.Entities;

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
    }
}
