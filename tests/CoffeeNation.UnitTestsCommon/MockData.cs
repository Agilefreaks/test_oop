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

        public static Location NullUserLocation => new Location
        {
            Tag = "User",
            X = -74.546,
            Y = -346.7654
        };

        public static Location UserLocation1 => new Location
        {
            Tag = "User",
            X = -74.546,
            Y = -346.7654
        };
    }
}
