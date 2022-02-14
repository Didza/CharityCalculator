using System;
using System.Collections.Generic;
using System.Text;

namespace CharityCalculator.Application.DTOs.EventType
{
    public class DonationOptimalSplitDto
    {
        public Guid EventTypeDtoId { get; set; }
        public decimal DonationAmount { get; set; }
    }
}
