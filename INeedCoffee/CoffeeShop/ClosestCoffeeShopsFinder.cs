using System;
using System.Collections.Generic;
using System.Linq;

namespace INeedCoffee
{
    public static class ClosestCoffeeShopsFinder
    {
        public static void Find(List<CoffeeShop> coffeeShopsList, int numberOfClosestCoffeeShopsToShow, int numberOfDecimalsToRoundDistanceTo)
        {
            var sortedCoffeeShopsListByDistance = CoffeeShopsDistanceSorting.Sort(coffeeShopsList);

            var closestCoffeeShopsList = sortedCoffeeShopsListByDistance.Take(numberOfClosestCoffeeShopsToShow);

            foreach (var closeCoffeeShop in closestCoffeeShopsList)
            {
                Console.WriteLine($"{closeCoffeeShop.Name} {MathUtilities.RoundValue(closeCoffeeShop.DistanceToUser, numberOfDecimalsToRoundDistanceTo)}");
            }
        }
    }
}