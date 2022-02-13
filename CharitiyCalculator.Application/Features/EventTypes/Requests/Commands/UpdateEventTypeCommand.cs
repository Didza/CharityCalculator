using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Responses;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Requests.Commands
{
    public class UpdateEventTypeCommand : IRequest<Unit>
    {
        public EventTypeDto EventTypeDto { get; set; }
    }
}
