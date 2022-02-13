using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Handlers.Queries
{
    public class GetEventTypeListRequestHandler : IRequestHandler<GetEventTypeListRequest, List<EventTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEventTypeListRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<EventTypeDto>> Handle(GetEventTypeListRequest request, CancellationToken cancellationToken)
        {
            var eventTypes = await _unitOfWork.EventTypeRepository.GetAll();
            return eventTypes.ToEventTypesDto();
        }
    }
}
