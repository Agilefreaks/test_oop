using System.Threading.Tasks;

namespace CoffeeNation.Data.Interfaces
{
    public interface IMessageDataWriter
    {
        Task WriteMessage(string message);
    }
}
