using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Data.Interfaces.Parser
{
    public interface ICsvLineParser
    {
        Task<Location> GetCoffeeShopLocation(string csvLine);
    }
}