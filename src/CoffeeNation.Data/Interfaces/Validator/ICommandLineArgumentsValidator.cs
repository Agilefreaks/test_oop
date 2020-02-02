using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeNation.Data.Interfaces.Validator
{
    public interface ICommandLineArgumentsValidator
    {
        Task ValidateLine(IEnumerable<string> commandLineTokens);
    }
}
