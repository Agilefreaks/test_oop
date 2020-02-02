using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Core.Interfaces
{
    public interface IDistanceSelector
    {
        Task<IEnumerable<Distance>> SelectDistances(IEnumerable<Distance> distances);
    }
}
