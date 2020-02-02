using System;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Interfaces;

namespace CoffeeNation.Core
{
    public class CartesianDistanceCalculator : IDistanceCalculator
    {
        public async Task<Distance> CalculateDistanceToDestination(Location source, Location destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            return new Distance()
            {
                Tag = destination.Tag,
                Value = await GetCartesianDistance(source, destination)
            };
        }

        private async Task<double> GetCartesianDistance(Location source, Location destination)
        {
            return await Task.Run(() => Math.Sqrt(Math.Pow(destination.X - source.X, 2) + Math.Pow(destination.Y - source.Y, 2)));
        }
    }
}
