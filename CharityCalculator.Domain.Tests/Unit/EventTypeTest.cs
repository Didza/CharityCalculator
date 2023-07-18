using System.Collections.Generic;
using CharityCalculator.Domain.Exceptions;
using CharityCalculator.Domain.Models;
using Shouldly;
using Xunit;

namespace CharityCalculator.Domain.Tests.Unit
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
            var eventType = new EventType("political", 5, 500000);
            eventType.SetMaximumDonationAmount(100000);
            eventType.MaximumDonationAmount.ShouldBe(100000);
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
            eventTypeDomainException.ShouldBeOfType<EventTypeDomainException>();
        }
        [Fact]
        public void ShouldThrowExceptionWhenChangingFromValidSupplementPercentageToInvalidSupplementPercentageTest()
        {
            var eventType = new EventType("sports", 5, 10000);
           
            var eventTypeDomainException = Should.Throw<EventTypeDomainException>(() => eventType.SetSupplementPercentage(-30));
            eventTypeDomainException.ShouldNotBeNull();
            eventTypeDomainException.ShouldBeOfType<EventTypeDomainException>();
        }

        [Fact]
        public void CanGetOptimalSplitsOfADonationAmountTest()
        {
            var eventType = new EventType("sports", 5, 40000);
            eventType.GetOptimalSplit(50000).ShouldAllBe(item => new List<decimal>(){40000m, 10000m}.Contains(item));
        }
    }
}
