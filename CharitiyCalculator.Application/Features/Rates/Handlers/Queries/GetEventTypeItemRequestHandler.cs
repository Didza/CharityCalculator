using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.Rate;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests.Queries;
using CharityCalculator.Application.Features.Rates.Requests.Queries;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Handlers.Queries
{
    public class GetRateItemRequestHandler : IRequestHandler<GetRateItemRequest, RateDto> { 
        private readonly IUnitOfWork _unitOfWork;

        public GetRateItemRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RateDto> Handle(GetRateItemRequest request, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var rate = await _unitOfWork.RateRepository.Get(request.Id);
                return rate.ToRateDto();
            }
        }
    }
}
