using CharityCalculator.Application.DTOs.Common;

namespace CharityCalculator.Application.DTOs.EventType
{
    public class EventTypeDto : BaseDto
    {
        public string Name { get; set; }
        public decimal SupplementInPercentage { get; set; }
        public decimal MaximumDonationAmount { get; set; }

    }
}
