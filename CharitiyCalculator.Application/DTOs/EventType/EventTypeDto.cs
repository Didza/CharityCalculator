using System.Linq;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs.Common;
using CharityCalculator.Application.DTOs.EventType.Validators;
using CharityCalculator.Application.Exceptions;
using CharityCalculator.Application.Responses;
using CharityCalculator.Application.ViewModel;

namespace CharityCalculator.Application.DTOs.EventType
{
    public class EventTypeDto : BaseDto
    {
        public string Name { get; set; }
        public decimal SupplementInPercentage { get; set; }
        public decimal MaximumDonationAmount { get; set; }

    }
}
