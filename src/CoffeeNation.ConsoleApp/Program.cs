using System;
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

            // await coffeeShopMapService.DisplayClosestCoffeeShops();

            // TODO: Handle exceptions properly
            try
            {
                var distances = await coffeeShopMapService.GetClosestCoffeeShops();

                // TODO: Output via output provider abstraction
                foreach (var distance in distances)
                {
                    Console.WriteLine($@"{distance.Tag} {distance.Value:F4}");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.ReadLine();
        }
    }
}