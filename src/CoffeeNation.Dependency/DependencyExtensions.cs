using System.Diagnostics.CodeAnalysis;
using CoffeeNation.Core;
using CoffeeNation.Core.Interfaces;
using CoffeeNation.Data;
using CoffeeNation.Data.Formatter;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Data.Interfaces.Formatter;
using CoffeeNation.Data.Interfaces.Parser;
using CoffeeNation.Data.Interfaces.Provider;
using CoffeeNation.Data.Parser;
using CoffeeNation.Data.Provider;
using CoffeeNation.Repository;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service;
using CoffeeNation.Service.Facade;
using CoffeeNation.Service.Interfaces;
using CoffeeNation.Service.Interfaces.Facade;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeNation.Dependency
{
    [ExcludeFromCodeCoverage]
    public static class DependencyExtensions
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services, string[] arguments)
        {
            services.AddCoreRegistrations();
            services.AddServiceRegistrations();
            services.AddRepositoryRegistrations();
            services.AddDataRegistrations(arguments);

            return services;
        }

        private static void AddCoreRegistrations(this IServiceCollection services)
        {
            services.AddSingleton<IDistanceCalculator, CartesianDistanceCalculator>();
            services.AddSingleton<IDistanceSelector, ClosestThreeDistancesSelector>();
        }

        private static void AddServiceRegistrations(this IServiceCollection services)
        {
            services.AddTransient<ICoffeeShopsQueryService, CoffeeShopsQueryService>();
            services.AddTransient<ICoffeeShopsDisplayService, CoffeeShopsDisplayService>();
            services.AddTransient<IMessagingService, MessagingService>();

            services.AddTransient<ICoffeeShopsQueryFacade, CoffeeShopsQueryFacade>();
            services.AddTransient<ICoffeeShopsDisplayFacade, CoffeeShopsDisplayFacade>();
        }

        private static void AddRepositoryRegistrations(this IServiceCollection services)
        {
            services.AddTransient<IUserLocationRepository, UserLocationRepository>();
            services.AddTransient<ICoffeeShopLocationRepository, CoffeeShopLocationRepository>();
            services.AddTransient<ICoffeeShopDistanceRepository, CoffeeShopDistanceRepository>();
            services.AddTransient<IOutputMessageRepository, OutputMessageRepository>();
        }

        private static void AddDataRegistrations(this IServiceCollection services, string[] arguments)
        {
            services.AddTransient<ICoffeeShopLocationDataReader, CsvCoffeeShopLocationDataReader>();
            services.AddTransient<IUserLocationDataReader, UserLocationDataReader>();
            services.AddTransient<ICoffeeShopDistanceDataWriter, CoffeeShopDistanceDataWriter>();
            services.AddTransient<IMessageDataWriter, ConsoleMessageDataWriter>();

            services.AddTransient<ICsvLineParser, CsvLineParser>();
            services.AddTransient<ICoffeeShopDistanceFormatter, CoffeeShopDistanceFormatter>();

            var userLocationX = arguments[0];
            var userLocationY = arguments[1];
            services.AddTransient<IUserLocationProvider>(factory => new UserLocationProvider(userLocationX, userLocationY));

            var csvFileName = arguments[2];
            services.AddTransient<ICsvContentProvider>(factory => new FileCsvContentProvider(csvFileName));

            services.AddTransient<IConsoleOutputProvider, ConsoleOutputProvider>();
        }
    }
}
