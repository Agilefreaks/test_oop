namespace INeedCoffee
{
    public static class CoffeeShopCSVFileDataValidator
    {
        public static bool Validate(string[] csvFileNameFromTerminalArguments)
        {
            var coffeeShopsCSVFile = CSVFileReader.Read(csvFileNameFromTerminalArguments);

            var coffeeShopCSVFileLineCount = 0;

            foreach (var coffeeShopCSVFileLine in coffeeShopsCSVFile)
            {
                coffeeShopCSVFileLineCount++;

                string[] coffeeShopCSVFileLineEntries = coffeeShopCSVFileLine.Split(',');

                if (coffeeShopCSVFileLineEntries.Length < 3)
                {
                    StandardMessages.DisplayValidationError("CSV file. Each line in the CSV file should " +
                    	"consist of 3 entries, separated by comma!");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(coffeeShopCSVFileLineEntries[0]))
                {
                    StandardMessages.DisplayValidationError("Coffee Shop name! Please correct the Coffee Shop name for the following Coffee Shop:");
                    StandardMessages.DisplayInformationalMessage($"Line number: {coffeeShopCSVFileLineCount} Data: {coffeeShopCSVFileLine}");
                    return false;
                }

                if (!double.TryParse(coffeeShopCSVFileLineEntries[1], out double dummyCoffeeShopLatitude))
                {
                    StandardMessages.DisplayValidationError($"Coffee Shop latitude! Please correct latitude for the following Coffee Shop:");
                    StandardMessages.DisplayInformationalMessage($"Line number: {coffeeShopCSVFileLineCount} Data: {coffeeShopCSVFileLine}");
                    return false;
                }

                if (!double.TryParse(coffeeShopCSVFileLineEntries[2], out double dummyCoffeeShopLongitude))
                {
                    StandardMessages.DisplayValidationError($"Coffee Shop longitude! Please correct longitude for the following Coffee Shop:");
                    StandardMessages.DisplayInformationalMessage($"Line number: {coffeeShopCSVFileLineCount} Data: {coffeeShopCSVFileLine}");
                    return false;
                }
            }

            return true;
        }
    }
}
