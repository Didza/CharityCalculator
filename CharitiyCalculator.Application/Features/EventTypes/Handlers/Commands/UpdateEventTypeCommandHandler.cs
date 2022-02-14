using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.Exceptions;
using CharityCalculator.Application.Features.EventTypes.Requests.Commands;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Handlers.Commands
{
    public class UpdateEventTypeCommandHandler : IRequestHandler<UpdateEventTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEventTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateEventTypeCommand request, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var eventType = await _unitOfWork.EventTypeRepository.Get(request.EventTypeDto.Id);

                if (eventType is null)
                    throw new NotFoundException(nameof(eventType), request.EventTypeDto.Id);

                eventType.Name = request.EventTypeDto.Name;
                eventType.SetSupplementPercentage(request.EventTypeDto.SupplementInPercentage);
                eventType.SetMaximumDonationAmount(request.EventTypeDto.MaximumDonationAmount);

                await _unitOfWork.EventTypeRepository.Update(eventType);
                await _unitOfWork.Save();

                return Unit.Value;
            }
        }
    }
}