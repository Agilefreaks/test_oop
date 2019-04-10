namespace INeedCoffee
{
    public static class DataProvidedValidator
    {
        public static void Validate(string[] terminalArguments)
        {
            bool terminalArgumentsAreValid = TerminalArgumentsValidator.Validate(terminalArguments);

            if (terminalArgumentsAreValid == false)
            {
                StandardMessages.DisplayExecutionArgumentsExample();
                StandardMessages.EndApplication();
                return;
            }

            TerminalArgumentsCommaDecimalSeparatorValidator.Validate(terminalArguments);

            bool csvFileDataIsValid = CoffeeShopCSVFileDataValidator.Validate(terminalArguments);

            if (csvFileDataIsValid == false)
            {
                StandardMessages.EndApplication();
                return;
            }
        }
    }
}
