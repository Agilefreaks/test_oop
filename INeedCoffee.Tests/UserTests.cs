using System;
using Xunit;
using INeedCoffee;

namespace INeedCoffee.Tests
{
    public class UserTests
    {
        [Fact]
        public void CaptureUserCoordinates_ShouldWork()
        {
            UserCoordinates userCoordinates = new UserCoordinates();

            string[] coordinates = { "45.7838552", "24.1515281" };

            UserCoordinatesCapture.Capture(userCoordinates, coordinates);

            string actual = userCoordinates.Latitude.ToString() + " " + userCoordinates.Longitude.ToString();

            string expected = "45.7838552 24.1515281";

            Assert.Equal(expected, actual);
        }
    }
}
