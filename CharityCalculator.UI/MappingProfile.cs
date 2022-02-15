using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CharityCalculator.UI.Models;
using CharityCalculator.UI.Services.Base;

namespace CharityCalculator.UI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventTypeDto, EventTypeVM>().ReverseMap();
            CreateMap<DonationOptimalSplitDto, DonationOptimalSplitVM>().ReverseMap();
            CreateMap<RateDto, RateVM>().ReverseMap();
            CreateMap<DeductibleAmountDto, DeductibleAmountVM>().ReverseMap();
        }
    }
}
