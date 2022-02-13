using System;

namespace CharityCalculator.Domain.Exceptions
{
    public class EventTypeDomainException : Exception
    {
        public EventTypeDomainException(string message) : base(message)
        { }
    }
}
