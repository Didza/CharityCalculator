using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.DTOs.EventType.Validators;
using CharityCalculator.Application.Exceptions;
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

        public static async Task ValidateEventTypeDto(this EventTypeDto eventTypeDto)
        {

            var validator = new EventTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(eventTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

        }
    }
}
