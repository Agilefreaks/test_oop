using CoffeeNation.Core.Interfaces;
using CoffeeNation.Repository.Interfaces;

namespace CoffeeNation.Service.Interfaces.Facade
{
    public interface ICoffeeShopsQueryFacade
    {
        IUserLocationRepository UserLocationRepository { get; }
        ICoffeeShopLocationRepository CoffeeShopLocationRepository { get; }
        IDistanceCalculator DistanceCalculator { get; }
        IDistanceSelector DistanceSelector { get; }
    }
}
