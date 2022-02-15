using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityCalculator.UI.Models;
using CharityCalculator.UI.Services.Base;

namespace CharityCalculator.UI.Contracts
{
    public interface IEventTypeService
    {
        Task<List<EventTypeVM>> GetEventTypes();
        Task<EventTypeVM> GetEventType(Guid id);
        Task<Response<Guid>> CreateEventType(EventTypeVM eventType);
        Task<Response<int>> UpdateEventType(EventTypeVM eventType);
        Task<Response<int>> DeleteEventType(Guid id);
        Task<ICollection<double>> GetDonationOptimalSplits(DonationOptimalSplitVM donationOptimalSplit);
    }
}
