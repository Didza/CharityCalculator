using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests;
using CharityCalculator.Application.Persistence.Contracts;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Handlers.Queries
{
    public class GetEventTypeListRequestHandler : IRequestHandler<GetEventTypeListRequest, List<EventTypeDto>>
    {
        private readonly IEventTypeRepository _eventTypeRepository;

        public GetEventTypeListRequestHandler(IEventTypeRepository eventTypeRepository)
        {
            _eventTypeRepository = eventTypeRepository;
        }
        public async Task<List<EventTypeDto>> Handle(GetEventTypeListRequest request, CancellationToken cancellationToken)
        {
            var eventTypes = await _eventTypeRepository.GetAll();
            return eventTypes.ToEventTypesDto();
        }
    }
}
