using System;
namespace INeedCoffee
{
    public static class StandardMessages
    {
        public static void DisplayValidationError(string fieldName)
        {
            Console.WriteLine($"You did not give us a valid { fieldName }");
        }

        public static void DisplayExecutionArgumentsExample()
        {
            Console.WriteLine("Example of command: dotnet INeedCoffee.dll 45.7838552 24.1515281 coffee_shops.csv");
        }

        public static void DisplayInformationalMessage(string informationalMessage)
        {
            Console.WriteLine(informationalMessage);
        }

        public static void EndApplication()
        {
            Environment.Exit(0);
        }
    }
}
