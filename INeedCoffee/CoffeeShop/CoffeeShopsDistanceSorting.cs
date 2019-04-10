using System.Collections.Generic;
using System.Linq;

namespace INeedCoffee
{
    public static class CoffeeShopsDistanceSorting
    {
        public static List<CoffeeShop> Sort(List<CoffeeShop> coffeeShopsList)
        {
            return coffeeShopsList.OrderBy(coffeeShop => coffeeShop.DistanceToUser).ToList();
        }
    }
}
