using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Core.Exceptions;
using CoffeeNation.Data.Interfaces.Parser;
using CoffeeNation.Data.Resources;

namespace CoffeeNation.Data.Parser
{
    public class CsvLineParser : ICsvLineParser
    {
        private const char SeparatorCharacter = ',';

        public async Task<Location> GetCoffeeShopLocation(string csvLine)
        {
            if (string.IsNullOrEmpty(csvLine))
            {
                throw new DataValidationException(ExceptionMessageResources.NullOrEmptyCsvLineExceptionMessage);
            }

            // TODO: Add the rest of validation scenarios

            var csvLineTokens = GetCsvLineTokens(csvLine);

            return new Location()
            {
                Tag = csvLineTokens[0],
                X = double.Parse(csvLineTokens[1]),
                Y = double.Parse(csvLineTokens[2])
            };
        }

        private string[] GetCsvLineTokens(string csvLine)
        {
            return csvLine != null
                ? csvLine.Split(SeparatorCharacter)
                : new string[] { };
        }
    }
}
