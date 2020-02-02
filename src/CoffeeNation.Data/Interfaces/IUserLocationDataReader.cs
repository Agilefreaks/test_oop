using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Data.Interfaces
{
    public interface IUserLocationDataReader
    {
        Task<Location> ReadUserLocation();
    }
}
