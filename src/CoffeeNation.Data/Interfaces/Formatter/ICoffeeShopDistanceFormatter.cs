using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Data.Interfaces.Formatter
{
    public interface ICoffeeShopDistanceFormatter
    {
        Task<string> GetFormattedDistance(Distance distance);
    }
}
