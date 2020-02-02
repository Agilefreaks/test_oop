using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeNation.Data.Interfaces.Validator
{
    public interface ICsvContentValidator
    {
        Task ValidateLine(IEnumerable<string> csvLineTokens);
    }
}
