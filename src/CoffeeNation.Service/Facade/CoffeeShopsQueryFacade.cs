using System;
using CoffeeNation.Core.Interfaces;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Interfaces.Facade;

namespace CoffeeNation.Service.Facade
{
    public class CoffeeShopsQueryFacade : ICoffeeShopsQueryFacade
    {
        public IUserLocationRepository UserLocationRepository { get; }
        public ICoffeeShopLocationRepository CoffeeShopLocationRepository { get; }
        public IDistanceCalculator DistanceCalculator { get; }
        public IDistanceSelector DistanceSelector { get; }

        public CoffeeShopsQueryFacade(IServiceProvider serviceProvider)
        {
            UserLocationRepository = (IUserLocationRepository)serviceProvider.GetService(typeof(IUserLocationRepository));
            CoffeeShopLocationRepository = (ICoffeeShopLocationRepository)serviceProvider.GetService(typeof(ICoffeeShopLocationRepository));
            DistanceCalculator = (IDistanceCalculator)serviceProvider.GetService(typeof(IDistanceCalculator));
            DistanceSelector = (IDistanceSelector)serviceProvider.GetService(typeof(IDistanceSelector));
        }
    }
}
