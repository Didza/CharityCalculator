using System;
using System.Collections.Generic;
using System.Linq;
using CharityCalculator.Domain.Exceptions;
using CharityCalculator.Domain.Models.Common;

namespace CharityCalculator.Domain.Models
{
    public class EventType: BaseEntity
    {
        public string Name { get; set; }
        public decimal SupplementInPercentage { get; private set; }
        public decimal MaximumDonationAmount { get;  private set; }

        public EventType(string name, decimal supplementInPercentage, decimal maximumDonationAmount)
        {
            ValidateSupplementPercentage(supplementInPercentage);
            ValidateMaximumDonationAmount(maximumDonationAmount);

            Name = name;
            SupplementInPercentage = supplementInPercentage;
            MaximumDonationAmount = maximumDonationAmount;
        }

        public decimal GetSupplementPercentageAsDecimal()
        {
            return SupplementInPercentage / 100;
        }

        public void SetSupplementPercentage(decimal supplementPercentage)
        {
            ValidateSupplementPercentage(supplementPercentage);
            SupplementInPercentage = supplementPercentage;
        }

        public void SetMaximumDonationAmount(decimal maximumDonationAmount)
        {
            ValidateMaximumDonationAmount(maximumDonationAmount);
            MaximumDonationAmount = maximumDonationAmount;
        }

        private static void ValidateSupplementPercentage(decimal supplementPercentage)
        {
            if (supplementPercentage < 0 || supplementPercentage > 100)
            {
                throw new EventTypeDomainException($"Invalid supplement percentage");
            }
        }

        private static void ValidateMaximumDonationAmount(decimal maximumDonationAmount)
        {
            if (maximumDonationAmount < 0)
            {
                throw new EventTypeDomainException($"Maximum donation amount may not be below 0");
            }
        }

        public List<decimal> GetOptimalSplit(decimal amount)
        {
            var remainingAmount = amount % MaximumDonationAmount;
            var numberOfDonations = Convert.ToInt32(Math.Floor(amount / MaximumDonationAmount));
            var optimalSplits = Enumerable.Repeat(decimal.Round(MaximumDonationAmount, 2), numberOfDonations).ToList();

            if (remainingAmount != 0)
                optimalSplits.Add(decimal.Round(remainingAmount, 2));
            return optimalSplits;
        }
    }
}
