using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Data.Interfaces.Provider;

namespace CoffeeNation.Data
{
    public class UserLocationDataReader : IUserLocationDataReader
    {
        private const string DefaultTag = "User";

        private readonly IUserLocationProvider _userLocationProvider;
        
        public UserLocationDataReader(IUserLocationProvider userLocationProvider)
        {
            _userLocationProvider = userLocationProvider;
        }

        public async Task<Location> ReadUserLocation()
        {
            var rawLocation = await _userLocationProvider.GetUserLocationCoordinates();

            return new Location
            {
                Tag = DefaultTag,
                X = rawLocation.Item1,
                Y = rawLocation.Item2
            };
        }
    }
}
