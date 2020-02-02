using System;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Dependency;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoffeeNation.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = RegisterServices();

            ConfigureServices(serviceProvider);

            await RunApplication(serviceProvider, args);
        }

        private static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();

            services.AddLogging();
            services.AddCoreRegistrations();

            return services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceProvider serviceProvider)
        {
            
        }

        private static async Task RunApplication(IServiceProvider serviceProvider, string[] args)
        {

        }

    }
}
