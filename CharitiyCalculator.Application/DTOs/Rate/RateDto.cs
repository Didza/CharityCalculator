using CharityCalculator.Application.DTOs.Common;
using static CharityCalculator.Domain.Types.Enums;

namespace CharityCalculator.Application.DTOs.Rate
{
    public class RateDto : BaseDto
    {
        public decimal RateInPercentage { get; set; }
        public RateType RateType { get; set; }
    }
}