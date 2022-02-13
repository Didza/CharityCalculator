using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Domain.Models;
using Microsoft.EntityFrameworkCore;
using static CharityCalculator.Domain.Types.Enums;

namespace CharityCalculator.Persistence.Repositories
{
    public class RateRepository : GenericRepository<Rate>, IRateRepository
    {
        private readonly CharityCalculatorDbContext _dbContext;

        public RateRepository(CharityCalculatorDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Rate> GetByRateType(RateType rateType)
        {
            return await _dbContext.Rates.FirstOrDefaultAsync(x => x.RateType == rateType);
        }
    }
}
