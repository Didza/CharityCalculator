using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.DTOs.Rate;
using CharityCalculator.Application.Responses;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Requests.Commands
{
    public class UpdateRateCommand : IRequest<Unit>
    {
        public RateDto RateDto { get; set; }
    }
}
