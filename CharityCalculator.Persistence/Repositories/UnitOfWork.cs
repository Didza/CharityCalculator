using System;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CharityCalculator.Persistence.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {

        private readonly BaseContext<T> _context;
        private IEventTypeRepository _eventTypeRepository;
        private IRateRepository _rateRepository;


        public UnitOfWork(BaseContext<T> context)
        {
            _context = context;
        }

        public IEventTypeRepository EventTypeRepository => _eventTypeRepository ??= new EventTypeRepository<T>(_context);
        public IRateRepository RateRepository => _rateRepository ??= new RateRepository<T>(_context);

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