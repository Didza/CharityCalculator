using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Requests.Commands
{
    public class DeleteEventTypeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
