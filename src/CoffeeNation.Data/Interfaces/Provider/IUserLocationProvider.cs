using System.Threading.Tasks;

namespace CoffeeNation.Data.Interfaces.Provider
{
    public interface IUserLocationProvider
    {
        Task<(double, double)> GetUserLocationCoordinates();
    }
}
