using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CoffeeNation.Dependency;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeNation.ConsoleApp
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        [ExcludeFromCodeCoverage]
        static async Task Main(string[] args)
        {
            await new Application(
                new ServiceCollection()
                    .ConfigureDependencies(args)
                    .BuildServiceProvider())
                .DisplayClosestCoffeeShops();
        }
    }
}