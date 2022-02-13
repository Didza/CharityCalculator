using System;
using System.Collections.Generic;
using System.Text;
using CharityCalculator.Application.DTOs.Common;

namespace CharityCalculator.Application.DTOs
{
    public class EventTypeDto : BaseDto
    {
        public string Name { get; set; }
        public decimal SupplementInPercentage { get; set; }
        public decimal MaximumDonationAmount { get; set; }
    }
}
