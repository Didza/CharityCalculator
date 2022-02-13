using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Domain.Models;

namespace CharityCalculator.Application.Extensions
{
    public static class RateExtensions
    {
        public static RateDto ToRateDto(this Rate rate)
        {
            return new RateDto()
            {
                Id = rate.Id,
                RateInPercentage = rate.RateInPercentage,
                RateType = rate.RateType
            };
        }

        public static List<RateDto> ToRatesDto(this IReadOnlyList<Rate> rates)
        {
            return rates.Select(item => item.ToRateDto()).ToList();
        }


        public static Rate ToRate(this RateDto rateDto)
        {
            return new Rate(rateDto.RateType, rateDto.RateInPercentage);

        }
    }
}
