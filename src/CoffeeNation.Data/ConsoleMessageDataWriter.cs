using System;
using System.Threading.Tasks;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Data.Interfaces.Provider;

namespace CoffeeNation.Data
{
    public class ConsoleMessageDataWriter : IMessageDataWriter
    {
        private readonly IConsoleOutputProvider _outputProvider;

        public ConsoleMessageDataWriter(IConsoleOutputProvider outputProvider)
        {
            _outputProvider = outputProvider;
        }

        public async Task WriteMessage(string message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            await _outputProvider.OutputStringLine(message);
        }
    }
}