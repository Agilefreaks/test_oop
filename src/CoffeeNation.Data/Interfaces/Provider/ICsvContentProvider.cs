using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeNation.Data.Interfaces.Provider
{
    public interface ICsvContentProvider
    {
        Task<IEnumerable<string>> GetCsvLines();
    }
}
