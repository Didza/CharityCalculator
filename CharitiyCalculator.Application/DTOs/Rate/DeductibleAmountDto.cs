using System;
using System.Collections.Generic;
using System.Text;
using static CharityCalculator.Domain.Types.Enums;

namespace CharityCalculator.Application.DTOs
{
    public class DeductibleAmountDto
    {
        public RateType RateType { get; set; }
        public Guid EventTypeDtoId { get; set; }
        public decimal DonationAmount { get; set; }
    }
}
