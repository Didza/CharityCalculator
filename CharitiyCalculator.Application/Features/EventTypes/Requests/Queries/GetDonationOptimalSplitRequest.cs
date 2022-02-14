using System.Collections.Generic;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.EventType;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Requests.Queries
{
    public class GetDonationOptimalSplitRequest : IRequest<List<decimal>>
    {
        public DonationOptimalSplitDto DonationOptimalSplitDto { get; set; }
    }
}
