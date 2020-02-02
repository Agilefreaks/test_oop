using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Repository.Interfaces
{
    public interface ICoffeeShopLocationRepository
    {
        Task<IEnumerable<Location>> GetCoffeeShopLocations();
    }
}
