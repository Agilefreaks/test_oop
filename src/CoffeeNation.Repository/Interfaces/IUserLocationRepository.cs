using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Repository.Interfaces
{
    public interface IUserLocationRepository
    {
        Task<Location> GetUserLocation();
    }
}
