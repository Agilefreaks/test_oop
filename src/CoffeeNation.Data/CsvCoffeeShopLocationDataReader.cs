using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Data.Interfaces;

namespace CoffeeNation.Data
{
    public class CsvCoffeeShopLocationDataReader : ICoffeeShopLocationDataReader
    {
        public Task<IEnumerable<Location>> ReadCoffeeShopLocations()
        {
            throw new NotImplementedException();
        }
    }
}
