using System.Diagnostics.CodeAnalysis;
using CoffeeNation.Core;
using CoffeeNation.Core.Interfaces;
using CoffeeNation.Data;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Data.Interfaces.Parser;
using CoffeeNation.Data.Interfaces.Provider;
using CoffeeNation.Data.Parser;
using CoffeeNation.Data.Provider;
using CoffeeNation.Repository;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service;
using CoffeeNation.Service.Interfaces;
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
            services.AddTransient<IDistanceCalculator, CartesianDistanceCalculator>();
            services.AddTransient<IDistanceSelector, ClosestThreeDistancesSelector>();
        }

        private static void AddServiceRegistrations(this IServiceCollection services)
        {
            services.AddTransient<ICoffeeShopsMapService, CoffeeShopsMapService>();
        }

        private static void AddRepositoryRegistrations(this IServiceCollection services)
        {
            services.AddTransient<IUserLocationRepository, UserLocationRepository>();
            services.AddTransient<ICoffeeShopLocationRepository, CoffeeShopLocationRepository>();
            services.AddTransient<ICoffeeShopDistanceRepository, CoffeeShopDistanceRepository>();
        }

        private static void AddDataRegistrations(this IServiceCollection services, string[] arguments)
        {
            services.AddTransient<ICoffeeShopLocationDataReader, CsvCoffeeShopLocationDataReader>();
            services.AddTransient<IUserLocationDataReader, UserLocationDataReader>();

            services.AddTransient<ICsvLineParser, CsvLineParser>();

            var userLocationX = arguments[0];
            var userLocationY = arguments[1];
            services.AddTransient<IUserLocationProvider>(factory => new UserLocationProvider(userLocationX, userLocationY));

            var csvFileName = arguments[2];
            services.AddTransient<ICsvContentProvider>(factory => new FileCsvContentProvider(csvFileName));
        }
    }
}
