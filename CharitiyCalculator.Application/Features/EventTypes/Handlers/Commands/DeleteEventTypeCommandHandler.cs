﻿using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.Exceptions;
using CharityCalculator.Application.Features.EventTypes.Requests.Commands;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Handlers.Commands
{
    public class DeleteEventTypeCommandHandler : IRequestHandler<DeleteEventTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEventTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteEventTypeCommand request, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                var eventType = await _unitOfWork.EventTypeRepository.Get(request.Id);

                if (eventType == null)
                    throw new NotFoundException(nameof(eventType), request.Id);

                await _unitOfWork.EventTypeRepository.Delete(eventType);
                await _unitOfWork.Save();

                return Unit.Value;
            }
        }
    }
}
