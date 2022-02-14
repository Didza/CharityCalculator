using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.Rate;
using CharityCalculator.Application.Exceptions;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests;
using CharityCalculator.Application.Features.Rates.Requests.Queries;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Handlers.Queries
{
    public class GetDeductibleAmountHandler : IRequestHandler<GetDeductibleAmountRequest, decimal>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDeductibleAmountHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<decimal> Handle(GetDeductibleAmountRequest request, CancellationToken cancellationToken)
        {
            var rate = await _unitOfWork.RateRepository.GetByRateType(request.DeductibleAmountDto.RateType);

            if (rate is null)
                throw new NotFoundException(nameof(rate), request.DeductibleAmountDto.RateType);

            var eventType = await _unitOfWork.EventTypeRepository.Get(request.DeductibleAmountDto.EventTypeDtoId);

            return rate.CalculateDeductibleAmount(request.DeductibleAmountDto.DonationAmount, eventType);
        }
    }
}
