using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Data.Interfaces.Formatter;
using CoffeeNation.Data.Interfaces.Provider;

namespace CoffeeNation.Data
{
    public class CoffeeShopDistanceDataWriter : ICoffeeShopDistanceDataWriter
    {
        private readonly ICoffeeShopDistanceFormatter _distanceFormatter;
        private readonly IConsoleOutputProvider _outputProvider;

        public CoffeeShopDistanceDataWriter(ICoffeeShopDistanceFormatter distanceFormatter, IConsoleOutputProvider outputProvider)
        {
            _distanceFormatter = distanceFormatter;
            _outputProvider = outputProvider;
        }

        public async Task WriteCoffeeShopDistances(IEnumerable<Distance> coffeeShopDistances)
        {
            if (coffeeShopDistances == null)
            {
                throw new ArgumentNullException(nameof(coffeeShopDistances));
            }

            foreach (var coffeeShopDistance in coffeeShopDistances)
            {
                var formattedDistance = await _distanceFormatter.GetFormattedDistance(coffeeShopDistance);

                await _outputProvider.OutputStringLine(formattedDistance);
            }
        }
    }
}
