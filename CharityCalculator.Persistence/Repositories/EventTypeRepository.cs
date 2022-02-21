using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CharityCalculator.Persistence.Repositories
{
    public class EventTypeRepository<T> : GenericRepository<EventType, T>, IEventTypeRepository where T : DbContext
    {
        private readonly BaseContext<T> _dbContext;

        public EventTypeRepository(BaseContext<T> dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EventType> GetByName(string name)
        {
            return await _dbContext.EventTypes.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
