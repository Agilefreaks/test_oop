using System;
using System.Threading.Tasks;
using CoffeeNation.ConsoleApp.Resources;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeNation.ConsoleApp
{
    public class Application
    {
        private readonly ICoffeeShopsQueryService _queryService;
        private readonly ICoffeeShopsDisplayService _displayService;
        private readonly IMessagingService _messagingService;

        public Application(IServiceProvider serviceProvider)
        {
            _queryService = serviceProvider.GetRequiredService<ICoffeeShopsQueryService>();
            _displayService = serviceProvider.GetRequiredService<ICoffeeShopsDisplayService>();
            _messagingService = serviceProvider.GetRequiredService<IMessagingService>();
        }

        public async Task DisplayClosestCoffeeShops()
        {
            try
            {
                var coffeeShopDistances = await _queryService.GetClosestCoffeeShops();

                await _displayService.DisplayCoffeeShopDistances(coffeeShopDistances);
            }
            catch (DataValidationException dataValidationException)
            {
                await _messagingService.SendErrorDetails(ExceptionMessageResources.DataValidationExceptionMessage, dataValidationException);
            }
            catch (DataProviderException dataProviderException)
            {
                await _messagingService.SendErrorDetails(ExceptionMessageResources.DataProviderExceptionMessage, dataProviderException);
            }
            catch (Exception genericException)
            {
                await _messagingService.SendErrorDetails(ExceptionMessageResources.GenericExceptionMessage, genericException);
            }
        }
    }
}
