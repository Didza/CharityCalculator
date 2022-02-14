using CharityCalculator.Application.DTOs;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Requests.Queries
{
    public class GetDeductibleAmountRequest : IRequest<decimal>
    {
        public DeductibleAmountDto DeductibleAmountDto { get; set; }
    }
}
