using System.Collections.Generic;
using CharityCalculator.Application.DTOs;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Requests.Queries
{
    public class GetRateListRequest : IRequest<List<RateDto>>
    {
    }
}
