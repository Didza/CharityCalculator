using System;
using System.Collections.Generic;
using System.Text;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.Rate;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Requests.Queries
{
    public class GetDeductibleAmountRequest : IRequest<decimal>
    {
        public DeductibleAmountDto DeductibleAmountDto { get; set; }
    }
}
