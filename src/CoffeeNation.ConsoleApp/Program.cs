using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CoffeeNation.Dependency;
using CoffeeNation.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeNation.ConsoleApp
{
    class Program
    {
        [ExcludeFromCodeCoverage]
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().ConfigureDependencies(args).BuildServiceProvider();

            var coffeeShopMapService = serviceProvider.GetRequiredService<ICoffeeShopsMapService>();

            await coffeeShopMapService.DisplayClosestCoffeeShops();
        }
    }
}