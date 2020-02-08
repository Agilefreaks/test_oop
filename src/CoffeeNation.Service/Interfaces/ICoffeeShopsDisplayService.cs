using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Service.Interfaces
{
    public interface ICoffeeShopsDisplayService
    {
        Task DisplayCoffeeShopDistances(IEnumerable<Distance> coffeeShopDistances);
    }
}
