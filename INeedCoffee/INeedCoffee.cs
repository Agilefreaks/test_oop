using System;
using System.Collections.Generic;

namespace INeedCoffee
{
    class INeedCoffee
    {
        private static void Main(string[] terminalArguments)
        {
            DataProvidedValidator.Validate(terminalArguments);

            UserCoordinates userCoordinates = new UserCoordinates();

            UserCoordinatesCapture.Capture(userCoordinates, terminalArguments);

            List<CoffeeShop> coffeeShopsList = new List<CoffeeShop>();

            CoffeeShopDataCapture.Capture(coffeeShopsList, terminalArguments);

            CoffeeShopDistanceCalculator.Calculate(userCoordinates, coffeeShopsList);

            int numberOfDecimalsToRoundTheDistanceTo = 4;

            int numberOfClosestCoffeeShopsToShow = 3;

            ClosestCoffeeShopsFinder.Find(coffeeShopsList, numberOfClosestCoffeeShopsToShow, numberOfDecimalsToRoundTheDistanceTo);
        }
    }
}
