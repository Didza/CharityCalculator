using System.Threading.Tasks;

namespace CharityCalculator.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IEventTypeRepository EventTypeRepository { get; }
        IRateRepository RateRepository { get; }
        Task Save();
    }
}
