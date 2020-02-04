using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Repository.Interfaces
{
    public interface ICoffeeShopDistanceRepository
    {
        Task SetCoffeeShopDistances(IEnumerable<Distance> distances);
    }
}
