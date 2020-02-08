using System;
using System.Threading.Tasks;
using CoffeeNation.Repository.Interfaces;
using CoffeeNation.Service.Interfaces;

namespace CoffeeNation.Service
{
    public class MessagingService : IMessagingService
    {
        private readonly IOutputMessageRepository _outputMessageRepository;

        public MessagingService(IOutputMessageRepository outputMessageRepository)
        {
            _outputMessageRepository = outputMessageRepository;
        }

        public async Task SendErrorDetails(string message, Exception exception)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentOutOfRangeException(nameof(message));
            }

            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            await _outputMessageRepository.SendMessage($"{message}: {exception.Message}");
        }
    }
}