using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Core.Interfaces
{
    public interface IDistanceCalculator
    {
        Task<Distance> CalculateDistanceToDestination(Location source, Location destination);
    }
}
