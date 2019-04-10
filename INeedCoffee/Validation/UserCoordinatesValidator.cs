namespace INeedCoffee
{
    public static class UserCoordinatesValidator
    {
        public static bool Validate(string[] coordinatesFromTerminalArguments)
        {
            if (!double.TryParse(coordinatesFromTerminalArguments[0], out double dummyUserLatitude))
            {
                StandardMessages.DisplayValidationError($"user latitude! Latitude given: {coordinatesFromTerminalArguments[0]}");
                return false;
            }

            if (!double.TryParse(coordinatesFromTerminalArguments[1], out double dummyUserLongitude))
            {
                StandardMessages.DisplayValidationError($"user longitude! Longitude given: {coordinatesFromTerminalArguments[1]}");
                return false;
            }

            return true;
        }
    }
}
