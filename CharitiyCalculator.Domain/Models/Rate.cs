using CharityCalculator.Domain.Exceptions;
using CharityCalculator.Domain.Models.Common;
using static CharityCalculator.Domain.Types.Enums;

namespace CharityCalculator.Domain.Models
{
    public class Rate : BaseEntity
    {
        public decimal RateInPercentage { get; private set; }
        public RateType RateType { get; set; }

        public Rate(RateType rateType, decimal rateInPercentage = 20)
        {
            ValidateRateInPercentage(rateInPercentage);

            RateInPercentage = rateInPercentage;
            RateType = rateType;
        }

        public void SetRateInPercentage(decimal rateInPercentage)
        {
            ValidateRateInPercentage(rateInPercentage);
            RateInPercentage = rateInPercentage;
        }

        private static void ValidateRateInPercentage(decimal rateInPercentage)
        {
            if (rateInPercentage < 0 || rateInPercentage > 100)
            {
                throw new RateDomainException($"Invalid percentage rate");
            }
        }

        public decimal CalculateDeductibleAmount(decimal donationAmount, EventType eventType = null)
        {
            if (donationAmount < 0)
            {
                throw new RateDomainException($"A donation amount can not be less than 0");
            }

            var deductibleAmount = 0.0m;

            if (RateType == RateType.TaxRate)
            {
                deductibleAmount = donationAmount * (RateInPercentage / (100 - RateInPercentage));

                if (eventType != null)
                {
                    deductibleAmount = donationAmount * (1 + eventType.GetSupplementPercentageAsDecimal()) * (RateInPercentage / (100 - RateInPercentage));
                }
            }

            return decimal.Round(deductibleAmount, 2);
        }

    }
}
