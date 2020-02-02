using System.Threading.Tasks;

namespace CoffeeNation.Data.Interfaces.Provider
{
    public interface ICommandLineArgumentsProvider
    {
        Task<string> GetCommandLineArguments();
    }
}
