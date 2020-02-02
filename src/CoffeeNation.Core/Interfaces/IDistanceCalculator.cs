using System.Threading.Tasks;

namespace CoffeeNation.Core.Interfaces
{
    public interface IDistanceCalculator
    {
        Task<double> CalculateDistance(double x1, double y1, double x2, double y2);
    }
}
