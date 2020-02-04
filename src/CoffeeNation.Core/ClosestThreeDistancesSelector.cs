using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Core.Interfaces;

namespace CoffeeNation.Core
{
    public class ClosestThreeDistancesSelector : IDistanceSelector
    {
        private const int DefaultOutputCount = 3;

        public async Task<IEnumerable<Distance>> SelectDistances(IEnumerable<Distance> distances)
        {
            if (distances == null)
            {
                throw new ArgumentValidationException(nameof(distances));
            }

            var distancesList = distances.ToList();
            if (distancesList.Count < DefaultOutputCount)
            {
                throw new ArgumentValidationException(nameof(distances));
            }

            return await Task.Run(() => distancesList.OrderBy(d => d.Value).Take(DefaultOutputCount));
        }
    }
}