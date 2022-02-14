using System;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Requests.Commands
{
    public class DeleteRateCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
