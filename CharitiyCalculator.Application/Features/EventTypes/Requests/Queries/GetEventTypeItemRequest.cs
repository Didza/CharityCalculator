using System;
using CharityCalculator.Application.DTOs.EventType;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Requests.Queries
{
    public class GetEventTypeItemRequest : IRequest<EventTypeDto>
    {
        public Guid Id { get; set; }
    }
}
