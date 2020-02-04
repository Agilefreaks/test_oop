﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Repository.Interfaces;

namespace CoffeeNation.Repository
{
    public class CoffeeShopDistanceRepository : ICoffeeShopDistanceRepository
    {
        private readonly ICoffeeShopDistanceDataWriter _dataWriter;
        public CoffeeShopDistanceRepository(ICoffeeShopDistanceDataWriter dataWriter)
        {
            _dataWriter = dataWriter;
        }

        public async Task SetCoffeeShopDistances(IEnumerable<Distance> distances)
        {
            if (distances == null)
            {
                throw new ArgumentValidationException(nameof(distances));
            }

            var distancesList = distances.ToList();
            if (distancesList.Count == 0)
            {
                throw new ArgumentValidationException(nameof(distances));
            }

            await _dataWriter.WriteCoffeeShopDistances(distancesList);
        }
    }
}
