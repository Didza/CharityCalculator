using System;
using System.Collections.Generic;
using System.Text;

namespace CharityCalculator.Application.Responses
{
    public class BaseResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
