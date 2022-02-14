using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.Exceptions;
using CharityCalculator.Application.Features.Rates.Requests.Commands;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Handlers.Commands
{
    public class DeleteRateCommandHandler : IRequestHandler<DeleteRateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteRateCommand request, CancellationToken cancellationToken)
        {
            var rate = await _unitOfWork.RateRepository.Get(request.Id);

            if (rate == null)
                throw new NotFoundException(nameof(rate), request.Id);

            await _unitOfWork.RateRepository.Delete(rate);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
