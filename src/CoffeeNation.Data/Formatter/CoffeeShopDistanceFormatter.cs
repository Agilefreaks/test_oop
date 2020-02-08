using System;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Data.Interfaces.Formatter;

namespace CoffeeNation.Data.Formatter
{
    public class CoffeeShopDistanceFormatter : ICoffeeShopDistanceFormatter
    {
        public async Task<string> GetFormattedDistance(Distance distance)
        {
            if (distance == null)
            {
                throw new ArgumentNullException(nameof(distance));
            }

            return await Task.Run(() => $@"{distance.Tag},{distance.Value:F4}");
        }
    }
}