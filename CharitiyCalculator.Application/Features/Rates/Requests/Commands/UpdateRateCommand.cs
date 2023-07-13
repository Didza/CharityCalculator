using CharityCalculator.Application.DTOs.Rate;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Requests.Commands
{
    public class UpdateRateCommand : IRequest<Unit>
    {
        public RateDto RateDto { get; set; }
    }
}
