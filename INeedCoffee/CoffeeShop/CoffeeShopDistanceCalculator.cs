using System.Collections.Generic;

namespace INeedCoffee
{
    public static class CoffeeShopDistanceCalculator
    {
        public static void Calculate(UserCoordinates userCoordinates, List<CoffeeShop> coffeeShopsList)
        {
                foreach (var coffeeShop in coffeeShopsList)
                {
                    coffeeShop.DistanceToUser = HaversineDistanceCalculator.Calculate(userCoordinates.Latitude,
                        userCoordinates.Longitude, coffeeShop.Latitude, coffeeShop.Longitude);
                }
        }
    }
}
