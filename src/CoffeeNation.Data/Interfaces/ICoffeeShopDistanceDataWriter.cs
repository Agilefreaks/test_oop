using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Data.Interfaces
{
    public interface ICoffeeShopDistanceDataWriter
    {
        Task WriteCoffeeShopDistances(IEnumerable<Distance> coffeeShopDistances);
    }
}
