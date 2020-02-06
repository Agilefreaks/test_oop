using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Data.Interfaces.Formatter;
using CoffeeNation.Data.Interfaces.Provider;

namespace CoffeeNation.Data
{
    public class CoffeeShopDistanceDataWriter : ICoffeeShopDistanceDataWriter
    {
        private readonly ICoffeeShopDistanceFormatter _formatter;
        private readonly IConsoleOutputProvider _outputProvider;

        public CoffeeShopDistanceDataWriter(ICoffeeShopDistanceFormatter formatter, IConsoleOutputProvider outputProvider)
        {
            _formatter = formatter;
            _outputProvider = outputProvider;
        }

        public async Task WriteCoffeeShopDistances(IEnumerable<Distance> coffeeShopDistances)
        {
            if (coffeeShopDistances == null)
            {
                throw new ArgumentValidationException(nameof(coffeeShopDistances));
            }

            foreach (var coffeeShopDistance in coffeeShopDistances)
            {
                var formattedDistance = await _formatter.GetFormattedDistance(coffeeShopDistance);

                await _outputProvider.OutputStringLine(formattedDistance);
            }
        }
    }
}
