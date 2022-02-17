using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CharityCalculator.UI.Models
{
    public class EventTypeVM : BaseVM
    {
        public string Name { get; set; }
        [Display(Name="Supplement In Percentage")]
        public decimal SupplementInPercentage { get; set; }
        [Display(Name="Maximum Donation Amount")]
        public decimal MaximumDonationAmount { get; set; }

    }

    public class DonationOptimalSplitVM
    {
        [Display(Name = "Event Type")]
        public Guid EventTypeDtoId { get; set; }
        public IEnumerable<SelectListItem> EventTypes { get; set; }
        [Display(Name = "Donation Amount")]
        public decimal DonationAmount { get; set; }
        public ICollection<double> SplitResult { get; set; }
    }
}
