using System;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;

namespace CharityCalculator.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CharityCalculatorDbContext _context;
        private IEventTypeRepository _eventTypeRepository;
        private IRateRepository _rateRepository;


        public UnitOfWork(CharityCalculatorDbContext context)
        {
            _context = context;
        }

        public IEventTypeRepository EventTypeRepository => _eventTypeRepository ??= new EventTypeRepository(_context);
        public IRateRepository RateRepository => _rateRepository ??= new RateRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {

            await _context.SaveChangesAsync();
        }
    }
}