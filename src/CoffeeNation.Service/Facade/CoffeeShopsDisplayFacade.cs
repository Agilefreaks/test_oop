using System;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Interfaces.Facade;

namespace CoffeeNation.Service.Facade
{
    public class CoffeeShopsDisplayFacade : ICoffeeShopsDisplayFacade
    {
        public ICoffeeShopDistanceRepository CoffeeShopDistanceRepository { get; }

        public CoffeeShopsDisplayFacade(IServiceProvider serviceProvider)
        {
            CoffeeShopDistanceRepository = (ICoffeeShopDistanceRepository)serviceProvider.GetService(typeof(ICoffeeShopDistanceRepository));
        }
    }
}
