using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityCalculator.UI.Models
{
    public class EventTypeVM : BaseVM
    {
        public string Name { get; set; }
        public decimal SupplementInPercentage { get; set; }
        public decimal MaximumDonationAmount { get; set; }

    }

    public class DonationOptimalSplitVM
    {
        public Guid EventTypeDtoId { get; set; }
        public decimal DonationAmount { get; set; }
    }
}
