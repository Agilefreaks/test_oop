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
        private const int RequiredTokensCount = 3;

        public async Task<Location> GetCoffeeShopLocation(string csvLine)
        {
            ValidateCsvLineString(csvLine);

            var csvLineTokens = await GetCsvLineTokens(csvLine);

            ValidateCsvLineTokens(csvLineTokens);

            return new Location()
            {
                Tag = csvLineTokens[0],
                X = double.Parse(csvLineTokens[1]),
                Y = double.Parse(csvLineTokens[2])
            };
        }

        private static void ValidateCsvLineString(string csvLine)
        {
            if (string.IsNullOrEmpty(csvLine))
            {
                throw new DataValidationException(ExceptionMessageResources.NullOrEmptyCsvLineExceptionMessage);
            }
        }

        private void ValidateCsvLineTokens(string[] csvLineTokens)
        {
            ValidateTokensCount(csvLineTokens);

            ValidateFirstToken(csvLineTokens);

            ValidateSecondToken(csvLineTokens);

            ValidateThirdToken(csvLineTokens);
        }

        private static void ValidateTokensCount(string[] csvLineTokens)
        {
            if (csvLineTokens.Length != RequiredTokensCount)
            {
                throw new DataValidationException(ExceptionMessageResources.IncorrectNumberOfTokensCsvLineExceptionMessage);
            }
        }

        private static void ValidateFirstToken(string[] csvLineTokens)
        {
            if (string.IsNullOrEmpty(csvLineTokens[0]))
            {
                throw new DataValidationException(ExceptionMessageResources.IncorrectValuePosition1CsvLineExceptionMessage);
            }
        }

        private static void ValidateSecondToken(string[] csvLineTokens)
        {
            if (!double.TryParse(csvLineTokens[1], out _))
            {
                throw new DataValidationException(ExceptionMessageResources.IncorrectValuePosition2CsvLineExceptionMessage);
            }
        }

        private static void ValidateThirdToken(string[] csvLineTokens)
        {
            if (!double.TryParse(csvLineTokens[2], out _))
            {
                throw new DataValidationException(ExceptionMessageResources.IncorrectValuePosition3CsvLineExceptionMessage);
            }
        }

        private async Task<string[]> GetCsvLineTokens(string csvLine)
        {
            return await Task.Run(
                () => csvLine != null
                    ? csvLine.Split(SeparatorCharacter)
                    : new string[] { });
        }
    }
}