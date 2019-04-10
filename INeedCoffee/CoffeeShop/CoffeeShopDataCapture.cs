using System.Collections.Generic;
namespace INeedCoffee
{
    public static class CoffeeShopDataCapture
    {
        public static List<CoffeeShop> Capture(List<CoffeeShop> coffeeShopsList, string[] csvFileNameFromTerminalArguments)
        {
            var coffeeShopsCSVFile = CSVFileReader.Read(csvFileNameFromTerminalArguments);

            foreach (var coffeeShopCSVFileLine in coffeeShopsCSVFile)
            {
                string[] coffeeShopCSVFileLineEntries = coffeeShopCSVFileLine.Split(',');

                CoffeeShop coffeeShop = new CoffeeShop
                {
                    Name = coffeeShopCSVFileLineEntries[0],
                    Latitude = double.Parse(coffeeShopCSVFileLineEntries[1]),
                    Longitude = double.Parse(coffeeShopCSVFileLineEntries[2])
                };
                coffeeShopsList.Add(coffeeShop);
            }

            return coffeeShopsList;
        }
    }
}
