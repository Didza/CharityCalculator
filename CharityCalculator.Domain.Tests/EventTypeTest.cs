using System.Collections.Generic;
using CharityCalculator.Domain.Exceptions;
using CharityCalculator.Domain.Models;
using CharityCalculator.Domain.Types;
using Shouldly;
using Xunit;

namespace CharityCalculator.Domain.Tests
{
    public class EventTypeTest
    {
        [Fact]
        public void CanCreateEventTypeTest()
        {
            var eventType = new EventType("sports", 5, 10000);

            eventType.Name.ShouldBe("sports");
            eventType.SupplementInPercentage.ShouldBe(5);
            eventType.MaximumDonationAmount.ShouldBe(10000);
        }

        [Fact]
        public void CanChangeSupplementPercentageTest()
        {
            var eventType = new EventType("sports", 5, 100000);
            eventType.SetSupplementPercentage(30) ;
            eventType.SupplementInPercentage.ShouldBe(30);
        }


        [Fact]
        public void CanChangeMaximumDonationAmountTest()
        {
            var eventType = new EventType("sports", 5, 100000);
            eventType.SetMaximumDonationAmount(30000);
            eventType.MaximumDonationAmount.ShouldBe(30000);
        }

        [Fact]
        public void CanGetSupplementPercentageAsDecimalTest()
        {
            var eventType = new EventType("sports", 5, 100000);
            eventType.GetSupplementPercentageAsDecimal().ShouldBe(0.05m);
        }

        [Fact]
        public void ShouldThrowExceptionWhenInvalidSupplementPercentageTest()
        {
            var eventTypeDomainException = Should.Throw<EventTypeDomainException>(() => new EventType("sports", -5, 10000));
            eventTypeDomainException.ShouldNotBeNull();
        }
        [Fact]
        public void ShouldThrowExceptionWhenChangingFromValidSupplementPercentageToInvalidSupplementPercentageTest()
        {
            var eventType = new EventType("sports", 5, 10000);
           
            var eventTypeDomainException = Should.Throw<EventTypeDomainException>(() => eventType.SetSupplementPercentage(-30));
            eventTypeDomainException.ShouldNotBeNull();
        }

        [Fact]
        public void CanGetOptimalSplitsOfADonationAmountTest()
        {
            var eventType = new EventType("sports", 5, 40000);
            eventType.GetOptimalSplit(50000).ShouldAllBe(item => new List<decimal>(){40000m, 10000m}.Contains(item));
        }
    }
}
