using System.Threading.Tasks;
using CharityCalculator.Domain.Models;
using static CharityCalculator.Domain.Types.Enums;

namespace CharityCalculator.Application.Contracts.Persistence
{
    public interface IRateRepository : IGenericRepository<Rate>
    {
        Task<Rate> GetByRateType(RateType rateType);
    }
}
