using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests.Commands;
using CharityCalculator.Application.Persistence.Contracts;
using CharityCalculator.Application.Responses;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Handlers.Commands
{
    public class CreateEventTypeCommandHandler : IRequestHandler<CreateEventTypeCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async  Task<BaseResponse> Handle(CreateEventTypeCommand request, CancellationToken cancellationToken)
        {
            var newEventType = request.EventTypeDto.ToEventType();

            var eventType = await _unitOfWork.EventTypeRepository.GetByName(newEventType.Name);

            if (eventType != null)
                return new BaseResponse()
                {
                    Success = true,
                    Message = "Event Type Already Exist",
                    Id = eventType.Id
                };

            eventType = await _unitOfWork.EventTypeRepository.Add(newEventType);
            await _unitOfWork.Save();

            return new BaseResponse()
            {
                Success = true,
                Message = "Creation Successful",
                Id = eventType.Id
            };

        }
    }
}
