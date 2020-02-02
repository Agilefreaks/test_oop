using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Data.Interfaces.Parser
{
    public interface ICommandLineArgumentsParser
    {
        Task<string> GetCoffeeShopDataSourceLocation();

        Task<Location> GetUserLocation();
    }
}
