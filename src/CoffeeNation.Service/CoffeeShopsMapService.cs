using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Interfaces;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Interfaces;

namespace CoffeeNation.Service
{
    public class CoffeeShopsMapService : ICoffeeShopsMapService
    {
        private readonly IUserLocationRepository _userLocationRepository;
        private readonly ICoffeeShopLocationRepository _coffeeShopLocationRepository;
        private readonly IDistanceCalculator _distanceCalculator;
        private readonly IDistanceSelector _distanceSelector;

        // TODO: Refactor and use a facade
        public CoffeeShopsMapService(
            IUserLocationRepository userLocationRepository, 
            ICoffeeShopLocationRepository coffeeShopLocationRepository, 
            IDistanceCalculator distanceCalculator,
            IDistanceSelector distanceSelector)
        {
            _userLocationRepository = userLocationRepository;
            _coffeeShopLocationRepository = coffeeShopLocationRepository;
            _distanceCalculator = distanceCalculator;
            _distanceSelector = distanceSelector;
        }

        public Task DisplayClosestCoffeeShops()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Distance>> GetClosestCoffeeShops()
        {
            var userLocation = await _userLocationRepository.GetUserLocation();
            var coffeeShopLocations = await _coffeeShopLocationRepository.GetCoffeeShopLocations();

            var allDistances = new List<Distance>();
            foreach (var coffeeShopLocation in coffeeShopLocations)
            {
                allDistances.Add(await _distanceCalculator.CalculateDistanceToDestination(userLocation, coffeeShopLocation));
            }

            return await _distanceSelector.SelectDistances(allDistances);
        }
    }
}
