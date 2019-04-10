namespace INeedCoffee
{
    public static class NumberOfDecimalsToRoundUpToValidator
    {
        public static int Validate(int numberOfDecimalsToRoundUpTo)
        {
            int minDecimalsValueCanBeRoundedTo = 0;
            int defaultDecimalsValueCanBeRoundedTo = 4;
            int maxDecimalsValueCanBeRoundedTo = 15;

            return numberOfDecimalsToRoundUpTo > maxDecimalsValueCanBeRoundedTo ? maxDecimalsValueCanBeRoundedTo 
                : numberOfDecimalsToRoundUpTo < minDecimalsValueCanBeRoundedTo ? defaultDecimalsValueCanBeRoundedTo 
                : numberOfDecimalsToRoundUpTo;
        }
    }
}
