using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs.Rate;
using CharityCalculator.Application.DTOs.Rate.Validators;
using CharityCalculator.Application.Exceptions;
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

        public static async Task ValidateRateDto(this RateDto rateDto)
        {

            var validator = new RateDtoValidator();
            var validationResult = await validator.ValidateAsync(rateDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

        }
    }
}
