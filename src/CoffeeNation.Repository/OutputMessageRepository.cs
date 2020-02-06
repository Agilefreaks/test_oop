using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Repository.Interfaces;

namespace CoffeeNation.Repository
{
    public class OutputMessageRepository : IOutputMessageRepository
    {
        private readonly IMessageDataWriter _dataWriter;

        public OutputMessageRepository(IMessageDataWriter dataWriter)
        {
            _dataWriter = dataWriter;
        }

        public async Task SendMessage(string message)
        {
            if (message == null)
            {
                throw new ArgumentValidationException(nameof(message));
            }

            await _dataWriter.WriteMessage(message);
        }
    }
}
