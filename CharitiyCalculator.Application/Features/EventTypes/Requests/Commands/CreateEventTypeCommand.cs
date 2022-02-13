using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.Responses;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Requests.Commands
{
    public class CreateEventTypeCommand : IRequest<BaseCommandResponse>
    {
        public EventTypeDto EventTypeDto { get; set; }
    }
}
