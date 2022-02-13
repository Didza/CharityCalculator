using System;

namespace CharityCalculator.Domain.Exceptions
{
    public class RateDomainException : Exception
    {
        public RateDomainException(string message) : base(message)
        { }
    }
}
