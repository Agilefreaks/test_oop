using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Interfaces;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Interfaces;
using CoffeeNation.Service.Interfaces.Facade;

namespace CoffeeNation.Service
{
    public class CoffeeShopsQueryService : ICoffeeShopsQueryService
    {
        private readonly IUserLocationRepository _userLocationRepository;
        private readonly ICoffeeShopLocationRepository _coffeeShopLocationRepository;

        private readonly IDistanceCalculator _distanceCalculator;
        private readonly IDistanceSelector _distanceSelector;

        public CoffeeShopsQueryService(ICoffeeShopsQueryFacade queryFacade)
        {
            _userLocationRepository = queryFacade.UserLocationRepository;
            _coffeeShopLocationRepository = queryFacade.CoffeeShopLocationRepository;
            _distanceCalculator = queryFacade.DistanceCalculator;
            _distanceSelector = queryFacade.DistanceSelector;
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
