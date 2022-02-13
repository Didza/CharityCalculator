using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.Responses;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Requests.Commands
{
    public class CreateRateCommand : IRequest<BaseResponse>
    {
        public RateDto RateDto { get; set; }
    }
}
