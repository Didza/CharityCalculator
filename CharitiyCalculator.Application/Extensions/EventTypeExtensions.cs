using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Domain.Models;

namespace CharityCalculator.Application.Extensions
{
    public static class EventTypeExtensions
    {
        public static EventTypeDto ToEventTypeDto(this EventType eventType)
        {
            return new EventTypeDto()
            {
                Id = eventType.Id,
                Name = eventType.Name,
                SupplementInPercentage = eventType.SupplementInPercentage,
                MaximumDonationAmount = eventType.MaximumDonationAmount
            };
        }

        public static List<EventTypeDto> ToEventTypesDto(this IReadOnlyList<EventType> eventTypes)
        {
            return eventTypes.Select(item => item.ToEventTypeDto()).ToList();
        }


        public static EventType ToEventType(this EventTypeDto eventTypeDto)
        {
            return new EventType(eventTypeDto.Name, eventTypeDto.SupplementInPercentage, eventTypeDto.MaximumDonationAmount);

        }
    }
}
