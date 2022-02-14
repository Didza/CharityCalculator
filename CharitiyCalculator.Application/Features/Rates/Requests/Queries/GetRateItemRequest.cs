using System;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.Rate;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Requests.Queries
{
    public class GetRateItemRequest : IRequest<RateDto>
    {
        public Guid Id { get; set; }
    }
}
