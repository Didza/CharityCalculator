using System;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.EventType;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Requests.Queries
{
    public class GetRateItemRequest : IRequest<EventTypeDto>, IRequest<RateDto>
    {
        public Guid Id { get; set; }
    }
}
