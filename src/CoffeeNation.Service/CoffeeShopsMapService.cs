using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Core.Interfaces;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Interfaces;
using CoffeeNation.Service.Resources;

namespace CoffeeNation.Service
{
    public class CoffeeShopsMapService : ICoffeeShopsMapService
    {
        private readonly IUserLocationRepository _userLocationRepository;
        private readonly ICoffeeShopLocationRepository _coffeeShopLocationRepository;
        private readonly ICoffeeShopDistanceRepository _coffeeShopDistanceRepository;
        private readonly IOutputMessageRepository _outputMessageRepository;

        private readonly IDistanceCalculator _distanceCalculator;
        private readonly IDistanceSelector _distanceSelector;

        // TODO: Refactor and use a facade
        public CoffeeShopsMapService(
            IUserLocationRepository userLocationRepository, 
            ICoffeeShopLocationRepository coffeeShopLocationRepository, 
            ICoffeeShopDistanceRepository coffeeShopDistanceRepository,
            IOutputMessageRepository outputMessageRepository,
            IDistanceCalculator distanceCalculator,
            IDistanceSelector distanceSelector)
        {
            _userLocationRepository = userLocationRepository;
            _coffeeShopLocationRepository = coffeeShopLocationRepository;
            _coffeeShopDistanceRepository = coffeeShopDistanceRepository;
            _outputMessageRepository = outputMessageRepository;
            _distanceCalculator = distanceCalculator;
            _distanceSelector = distanceSelector;
        }

        public async Task DisplayClosestCoffeeShops()
        {
            try
            {
                var coffeeShopDistances = await GetClosestCoffeeShops();

                await DisplayCoffeeShops(coffeeShopDistances);
            }
            catch (DataValidationException dataValidationException)
            {
                await _outputMessageRepository
                    .SendMessage($"{CoffeeShopMapServiceResources.DataValidationExceptionMessage}: {dataValidationException.Message}");
            }
            catch (DataProviderException dataProviderException)
            {
                await _outputMessageRepository
                    .SendMessage($"{CoffeeShopMapServiceResources.DataProviderExceptionMessage}: {dataProviderException.Message}");
            }
            catch (Exception genericException)
            {
                await _outputMessageRepository
                    .SendMessage($"{CoffeeShopMapServiceResources.GenericExceptionMessage}: {genericException.Message}");
            }
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

        public async Task DisplayCoffeeShops(IEnumerable<Distance> coffeeShopDistances)
        {
            if (coffeeShopDistances == null)
            {
                throw new ArgumentValidationException(nameof(coffeeShopDistances));
            }

            var coffeeShopDistancesList = coffeeShopDistances.ToList();
            if (coffeeShopDistancesList.Count == 0)
            {
                throw new ArgumentValidationException(nameof(coffeeShopDistances));
            }

            await _coffeeShopDistanceRepository.SetCoffeeShopDistances(coffeeShopDistancesList);
        }
    }
}
