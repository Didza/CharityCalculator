using System.Linq;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs.Common;
using CharityCalculator.Application.DTOs.EventType.Validators;
using CharityCalculator.Application.Exceptions;
using CharityCalculator.Application.Responses;
using CharityCalculator.Application.ViewModel;

namespace CharityCalculator.Application.DTOs.EventType
{
    public class EventTypeDto : BaseDto
    {
        public string Name { get; set; }
        public decimal SupplementInPercentage { get; set; }
        public decimal MaximumDonationAmount { get; set; }

        public static async Task<EventTypeDto> FromJson(EventTypeViewModel eventTypeViewModel)
        {
            var eventTypeDto = new EventTypeDto()
            {
                Name = eventTypeViewModel.Name,
                SupplementInPercentage = eventTypeViewModel.SupplementInPercentage,
                MaximumDonationAmount = eventTypeViewModel.MaximumDonationAmount
            };
            var validator = new EventTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(eventTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            return eventTypeDto;
        }
    }
}
