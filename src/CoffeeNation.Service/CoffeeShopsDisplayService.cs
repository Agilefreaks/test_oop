using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Interfaces;
using CoffeeNation.Service.Interfaces.Facade;

namespace CoffeeNation.Service
{
    public class CoffeeShopsDisplayService : ICoffeeShopsDisplayService
    {
        private readonly ICoffeeShopDistanceRepository _coffeeShopDistanceRepository;

        public CoffeeShopsDisplayService(ICoffeeShopsDisplayFacade displayFacade)
        {
            _coffeeShopDistanceRepository = displayFacade.CoffeeShopDistanceRepository;
        }

        public async Task DisplayCoffeeShopDistances(IEnumerable<Distance> coffeeShopDistances)
        {
            if (coffeeShopDistances == null)
            {
                throw new ArgumentNullException(nameof(coffeeShopDistances));
            }

            var coffeeShopDistancesList = coffeeShopDistances.ToList();
            if (coffeeShopDistancesList.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(coffeeShopDistances));
            }

            await _coffeeShopDistanceRepository.SetCoffeeShopDistances(coffeeShopDistancesList);
        }
    }
}
