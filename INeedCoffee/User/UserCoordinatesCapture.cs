namespace INeedCoffee
{
    public static class UserCoordinatesCapture
    {
        public static UserCoordinates Capture(UserCoordinates userCoordinates, string[] coordinatesFromTerminalArguments)
        {
            userCoordinates.Latitude = double.Parse(coordinatesFromTerminalArguments[0]);

            userCoordinates.Longitude = double.Parse(coordinatesFromTerminalArguments[1]);

            return userCoordinates;
        }
    }
}
