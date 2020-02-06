using System;

namespace CoffeeNation.Core.Exceptions
{
    public class DataProviderException : Exception
    {
        public DataProviderException(string message) : base(message)
        {
        }
    }
}
