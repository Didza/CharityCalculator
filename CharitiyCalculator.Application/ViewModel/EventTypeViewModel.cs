using System;
using System.Collections.Generic;
using System.Text;

namespace CharityCalculator.Application.ViewModel
{
    public class EventTypeViewModel
    {
        public string Name { get; set; }
        public decimal SupplementInPercentage { get; set; }
        public decimal MaximumDonationAmount { get; set; }
    }
}
