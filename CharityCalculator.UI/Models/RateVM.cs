using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityCalculator.UI.Services.Base;

namespace CharityCalculator.UI.Models
{
    public class RateVM : BaseVM
    {
        public decimal RateInPercentage { get; set; }
        public RateType RateType { get; set; }
    }

    public class DeductibleAmountVM
    {
        public RateType RateType { get; set; }
        public Guid EventTypeDtoId { get; set; }
        public decimal DonationAmount { get; set; }
    }
}
