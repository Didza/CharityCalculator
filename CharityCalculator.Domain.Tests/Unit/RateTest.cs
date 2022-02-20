using CharityCalculator.Domain.Exceptions;
using CharityCalculator.Domain.Models;
using Shouldly;
using Xunit;
using static CharityCalculator.Domain.Types.Enums;

namespace CharityCalculator.Domain.Tests.Unit
{
    public class RateTest
    {
        [Fact]
        public void CanCreateTaxRateWithDefaultTwentyPercentageRateTest()
        {
            var taxRate = new Rate(RateType.TaxRate);

            taxRate.RateInPercentage.ShouldBe(20);
            taxRate.RateType.ShouldBe(RateType.TaxRate);
        }

        [Fact]
        public void CanChangeRateInPercentageTest()
        {
            var taxRate = new Rate(RateType.TaxRate);
            taxRate.SetRateInPercentage(75);
            taxRate.RateInPercentage.ShouldBe(75);
        }

        [Fact]
        public void CanCalculateCorrectDeductibleAmountTest()
        {
            var taxRate = new Rate(RateType.TaxRate);

            taxRate.CalculateDeductibleAmount(2000).ShouldBe(500.00m);
        }

        [Fact]
        public void CanCalculateCorrectDeductibleAmountForEventTypeTest()
        {
            var taxRate = new Rate(RateType.TaxRate);
            var eventType = new EventType("sport", 5, 1000);

            taxRate.CalculateDeductibleAmount(2000, eventType).ShouldBe(525.00m);
        }


        [Fact]
        public void ShouldThrowExceptionWhenInvalidTaxRatePercentageTest()
        {
            var rateDomainException = Should.Throw<RateDomainException>(() => new Rate(RateType.TaxRate, -20));
            rateDomainException.ShouldNotBeNull();
            rateDomainException.ShouldBeOfType<RateDomainException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenSettingRateFromValidToInvalidTaxRatePercentageTest()
        {
            var taxRate = new Rate(RateType.TaxRate);
            var rateDomainException = Should.Throw<RateDomainException>(() => taxRate.SetRateInPercentage(-75));
            rateDomainException.ShouldNotBeNull();
            rateDomainException.ShouldBeOfType<RateDomainException>();
        }

        [Fact]
        public void ShouldThrowExceptionWhenInvalidDonationAmountTest()
        {
            var taxRate = new Rate(RateType.TaxRate);

            var rateDomainException = Should.Throw<RateDomainException>(() =>taxRate.CalculateDeductibleAmount(-2000));
            rateDomainException.ShouldNotBeNull();
            rateDomainException.ShouldBeOfType<RateDomainException>();
        }

    }
}
