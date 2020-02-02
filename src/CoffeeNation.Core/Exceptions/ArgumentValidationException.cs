using System;

namespace CoffeeNation.Core.Exceptions
{
    public class ArgumentValidationException : Exception
    {
        public ArgumentValidationException() : base()
        {
        }

        public ArgumentValidationException(string argument) : base($"{argument}")
        {
        }
    }
}
