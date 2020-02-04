using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Repository.Interfaces;

namespace CoffeeNation.Repository
{
    public class CoffeeShopLocationRepository : ICoffeeShopLocationRepository
    {
        private readonly ICoffeeShopLocationDataReader _dataReader;

        public CoffeeShopLocationRepository(ICoffeeShopLocationDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public async Task<IEnumerable<Location>> GetCoffeeShopLocations()
        {
            return await _dataReader.ReadCoffeeShopLocations();
        }
    }
}
