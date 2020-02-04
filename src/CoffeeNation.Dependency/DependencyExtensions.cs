﻿using System.Diagnostics.CodeAnalysis;
using CoffeeNation.Core;
using CoffeeNation.Core.Interfaces;
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
            services.AddTransient<ICoffeeShopLocationRepository, CoffeeShopLocationRepository>();
            services.AddTransient<IUserLocationRepository, UserLocationRepository>();
        }

        private static void AddDataRegistrations(this IServiceCollection services, string[] arguments)
        {

        }
    }
}
