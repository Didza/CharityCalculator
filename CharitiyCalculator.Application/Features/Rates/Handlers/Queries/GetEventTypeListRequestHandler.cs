using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.Rate;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests;
using CharityCalculator.Application.Features.Rates.Requests.Queries;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Handlers.Queries
{
    public class GetRateListRequestHandler : IRequestHandler<GetRateListRequest, List<RateDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRateListRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<RateDto>> Handle(GetRateListRequest request, CancellationToken cancellationToken)
        {
            var rates = await _unitOfWork.RateRepository.GetAll();
            return rates.ToRatesDto();
        }
    }
}
