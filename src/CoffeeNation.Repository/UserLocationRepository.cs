using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Repository.Interfaces;

namespace CoffeeNation.Repository
{
    public class UserLocationRepository : IUserLocationRepository
    {
        private readonly IUserLocationDataReader _dataReader;
        public UserLocationRepository(IUserLocationDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public async Task<Location> GetUserLocation()
        {
            return await _dataReader.ReadUserLocation();
        }
    }
}
