using CharityCalculator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CharityCalculator.Application.Persistence.Contracts
{
    public interface IEventTypeRepository : IGenericRepository<EventType>
    {
        Task<EventType> GetByName(string name);
    }
}
