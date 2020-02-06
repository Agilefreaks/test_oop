using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;
using CoffeeNation.Data.Interfaces;
using CoffeeNation.Data.Interfaces.Parser;
using CoffeeNation.Data.Interfaces.Provider;

namespace CoffeeNation.Data
{
    public class CsvCoffeeShopLocationDataReader : ICoffeeShopLocationDataReader
    {
        private readonly ICsvContentProvider _csvContentProvider;
        private readonly ICsvLineParser _csvContentParser;

        public CsvCoffeeShopLocationDataReader(ICsvContentProvider csvContentProvider, ICsvLineParser csvContentParser)
        {
            _csvContentProvider = csvContentProvider;
            _csvContentParser = csvContentParser;
        }

        public async Task<IEnumerable<Location>> ReadCoffeeShopLocations()
        {
            var shopLocations = new List<Location>();

            var csvContentLines = await _csvContentProvider.GetCsvLines();

            foreach (var csvContentLine in csvContentLines)
            {
                shopLocations.Add(await _csvContentParser.GetCoffeeShopLocation(csvContentLine));
            }

            return shopLocations;
        }
    }
}
