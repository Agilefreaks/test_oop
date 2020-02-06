using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces.Provider;

namespace CoffeeNation.Data.Provider
{
    [ExcludeFromCodeCoverage]
    public class ConsoleOutputProvider : IConsoleOutputProvider
    {
        public async Task OutputStringLine(string output)
        {
            try
            {
                await Task.Run(() => Console.WriteLine(output));
            }
            catch (Exception exception)
            {
                throw new DataProviderException(exception.Message);
            }
        }
    }
}
