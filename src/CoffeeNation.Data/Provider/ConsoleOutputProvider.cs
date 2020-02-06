using System;
using System.Threading.Tasks;
using CoffeeNation.Data.Interfaces.Provider;

namespace CoffeeNation.Data.Provider
{
    public class ConsoleOutputProvider : IConsoleOutputProvider
    {
        public async Task OutputStringLine(string output)
        {
            await Task.Run(() => Console.WriteLine(output));
        }
    }
}
