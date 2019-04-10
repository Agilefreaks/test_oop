using System;

namespace INeedCoffee
{
    public static class HaversineDistanceCalculator
    {
        public static double Calculate(double firstLatitude, double firstLongitude, double secondLatitude, double secondLongitude)
        {
            var earthRadiusInKm = 6372.8;
            var deltaLatitude = MathUtilities.ConvertToRadians(secondLatitude - firstLatitude);
            var deltaLongitude = MathUtilities.ConvertToRadians(secondLongitude - firstLongitude);
            firstLatitude = MathUtilities.ConvertToRadians(firstLatitude);
            secondLatitude = MathUtilities.ConvertToRadians(secondLatitude);

            var a = Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) + Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2) * Math.Cos(firstLatitude) * Math.Cos(secondLatitude);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return (double)(earthRadiusInKm * 2 * Math.Asin(Math.Sqrt(a)));
        }
    }
}
