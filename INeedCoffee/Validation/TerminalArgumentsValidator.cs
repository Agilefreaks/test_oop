using System;
using System.IO;

namespace INeedCoffee
{
    public static class TerminalArgumentsValidator
    {
            public static bool Validate(string[] terminalArguments)
            {
                if (terminalArguments.Length < 3)
                {
                    StandardMessages.DisplayValidationError("CSV file name (string), user latitude (double) and user longitude (double)!");
                    return false;
                }

            bool filePathGivenIsValid = CSVFilePathValidator.Validate(terminalArguments);

            if(filePathGivenIsValid == false)
            {
                return false;
            }

            bool coordinatesAreValid = UserCoordinatesValidator.Validate(terminalArguments);

            if (coordinatesAreValid == false)
            {
                return false;
            }

            return true;
            }
    }
}
