using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.Exceptions;
using CharityCalculator.Application.Features.EventTypes.Requests.Queries;
using CharityCalculator.Application.Features.Rates.Requests.Queries;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Handlers.Queries
{
    public class GetDonationOptimalSplitHandler : IRequestHandler<GetDonationOptimalSplitRequest, List<decimal>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDonationOptimalSplitHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<decimal>> Handle(GetDonationOptimalSplitRequest request, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var eventType = await _unitOfWork.EventTypeRepository.Get(request.DonationOptimalSplitDto.EventTypeDtoId);

                if (eventType is null)
                    throw new NotFoundException(nameof(eventType), request.DonationOptimalSplitDto.EventTypeDtoId);

                return eventType.GetOptimalSplit(request.DonationOptimalSplitDto.DonationAmount);
            }
        }
    }
}
