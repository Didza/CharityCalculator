using System.Threading.Tasks;
using CharityCalculator.Domain.Models;

namespace CharityCalculator.Application.Contracts.Persistence
{
    public interface IEventTypeRepository : IGenericRepository<EventType>
    {
        Task<EventType> GetByName(string name);
    }
}
