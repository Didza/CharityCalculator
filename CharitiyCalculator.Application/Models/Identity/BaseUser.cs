using System;

namespace CharityCalculator.Application.Models.Identity
{
    public class BaseUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
