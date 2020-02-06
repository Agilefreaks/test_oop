using System;

namespace CoffeeNation.Core.Exceptions
{
    public class DataValidationException : Exception
    {
        public DataValidationException(string message) : base(message)
        {
        }
    }
}
