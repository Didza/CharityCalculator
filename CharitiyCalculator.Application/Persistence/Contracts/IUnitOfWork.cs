using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CharityCalculator.Application.Persistence.Contracts
{
    public interface IUnitOfWork
    {
        IEventTypeRepository EventTypeRepository { get; }
        IRateRepository RateRepository { get; }
        Task Save();
    }
}
