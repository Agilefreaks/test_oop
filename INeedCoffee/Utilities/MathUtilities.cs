using System;
namespace INeedCoffee
{
    public static class MathUtilities
    {
        public static double ConvertToRadians(double angle)
        {
            return (double)(Math.PI * angle / 180.0);
        }

        public static double RoundValue(double valueToRoundUp, int numberOfDecimalsToRoundUpTo)
        {
            int validNumberOfDecimalsToRoundUpTo = NumberOfDecimalsToRoundUpToValidator.Validate(numberOfDecimalsToRoundUpTo);

            return (double)Math.Round(valueToRoundUp, validNumberOfDecimalsToRoundUpTo);
        }
    }
}
