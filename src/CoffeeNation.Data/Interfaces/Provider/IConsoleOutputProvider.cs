using System.Threading.Tasks;

namespace CoffeeNation.Data.Interfaces.Provider
{
    public interface IConsoleOutputProvider
    {
        Task OutputStringLine(string output);
    }
}
