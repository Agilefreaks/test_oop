using CoffeeNation.Repository.Interfaces;

namespace CoffeeNation.Service.Interfaces.Facade
{
    public interface ICoffeeShopsDisplayFacade
    {
        ICoffeeShopDistanceRepository CoffeeShopDistanceRepository { get; }
    }
}
