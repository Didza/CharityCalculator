using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests.Queries;
using CharityCalculator.Application.Persistence.Contracts;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Handlers.Queries
{
    public class GetEventTypeItemRequestHandler : IRequestHandler<GetEventTypeItemRequest, EventTypeDto>
    {
        private readonly IEventTypeRepository _eventTypeRepository;

        public GetEventTypeItemRequestHandler(IEventTypeRepository eventTypeRepository)
        {
            _eventTypeRepository = eventTypeRepository;
        }

        public async Task<EventTypeDto> Handle(GetEventTypeItemRequest request, CancellationToken cancellationToken)
        {
            var eventType = await _eventTypeRepository.Get(request.Id);
            return eventType.ToEventTypeDto();
        }
    }
}
