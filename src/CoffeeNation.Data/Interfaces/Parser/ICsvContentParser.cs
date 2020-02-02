using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeNation.Core.Entities;

namespace CoffeeNation.Data.Interfaces.Parser
{
    public interface ICsvContentParser
    {
        Task<IEnumerable<Location>> ParseCsvLines(IEnumerable<string> csvLines);
    }
}
