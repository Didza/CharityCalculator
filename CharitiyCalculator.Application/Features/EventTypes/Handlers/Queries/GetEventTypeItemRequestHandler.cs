using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests.Queries;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Handlers.Queries
{
    public class GetEventTypeItemRequestHandler : IRequestHandler<GetEventTypeItemRequest, EventTypeDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventTypeItemRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EventTypeDto> Handle(GetEventTypeItemRequest request, CancellationToken cancellationToken)
        {
            var eventType = await _unitOfWork.EventTypeRepository.Get(request.Id);
            return eventType.ToEventTypeDto();
        }
    }
}
