namespace CoffeeNation.UnitTestsCommon
{
    public static class MockValues
    {
        public const int DefaultOutputDistancesCount = 3;

        public const string CsvDataValidationExceptionMessage = "Invalid CSV Data";
        public const string CommandLineDataValidationExceptionMessage = "Invalid command line args";
        public const string CsvDataProviderExceptionMessage = "Error providing CSV Data";
        public const string UserLocationDataProviderExceptionMessage = "Error providing User Location Data";
        public const string OutputDataProviderExceptionMessage = "Error providing Output Data";

        // Data validation exception messages
        public const string NullOrEmptyCsvLineExceptionMessage = "CSV line is null or empty";
        public const string IncorrectNumberOfTokensCsvLineExceptionMessage = "The number of tokens in CSV line is incorrect (should be 3)";
        public const string IncorrectValuePosition1CsvLineExceptionMessage = "The value expected on CSV line position 1 (coffee shop name) is incorrect";
        public const string IncorrectValuePosition2CsvLineExceptionMessage = "The value expected on CSV line position 2 (coffee shop coordinate X) is incorrect";
        public const string IncorrectValuePosition3CsvLineExceptionMessage = "The value expected on CSV line position 3 (coffee shop coordinate Y) is incorrect";

    }
}
