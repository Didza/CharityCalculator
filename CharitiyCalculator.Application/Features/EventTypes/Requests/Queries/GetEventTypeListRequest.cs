using System.Collections.Generic;
using CharityCalculator.Application.DTOs;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Requests
{
    public class GetEventTypeListRequest : IRequest<List<EventTypeDto>>
    {
    }
}
