using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CharityCalculator.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CharityCalculator.UI.Models
{
    public class RateVM : BaseVM
    {
        [Display(Name = "Rate In Percentage")]
        public decimal RateInPercentage { get; set; }
        [Display(Name = "Rate Type")]
        public RateType RateType { get; set; }
        public IEnumerable<SelectListItem> RateTypes { get; set; }
    }

    public class DeductibleAmountVM
    {
        public IEnumerable<SelectListItem> RateTypes { get; set; }
        [Display(Name = "Rate Type")]
        public RateType RateType { get; set; }
        public IEnumerable<SelectListItem> EventTypes { get; set; }
        [Display(Name = "Event Type")]
        public Guid EventTypeDtoId { get; set; }
        public decimal DonationAmount { get; set; }
        public double DeductibleAmountResult { get; set; }
    }
}
