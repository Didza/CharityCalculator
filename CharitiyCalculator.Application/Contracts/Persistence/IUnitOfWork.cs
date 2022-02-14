using System;
using System.Threading.Tasks;

namespace CharityCalculator.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IEventTypeRepository EventTypeRepository { get; }
        IRateRepository RateRepository { get; }
        Task Save();
    }
}
