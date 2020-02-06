using System;
using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces.Provider;

namespace CoffeeNation.Data.Provider
{
    public class UserLocationProvider : IUserLocationProvider
    {
        private readonly string _locationX;
        private readonly string _locationY;

        public UserLocationProvider(string locationX, string locationY)
        {
            _locationX = locationX;
            _locationY = locationY;
        }

        public async Task<(double, double)> GetUserLocationCoordinates()
        {
            try
            {
                return await Task.Run(() => (double.Parse(_locationX), double.Parse(_locationY)));
            }
            catch (Exception exception)
            {
                throw new DataProviderException(exception.Message);
            }
        }
    }
}