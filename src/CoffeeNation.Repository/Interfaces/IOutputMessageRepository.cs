using System.Threading.Tasks;

namespace CoffeeNation.Repository.Interfaces
{
    public interface IOutputMessageRepository
    {
        Task SendMessage(string message);
    }
}
