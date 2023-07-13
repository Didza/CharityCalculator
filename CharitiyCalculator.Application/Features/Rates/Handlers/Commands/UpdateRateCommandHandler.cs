using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.Exceptions;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests.Commands;
using MediatR;

namespace CharityCalculator.Application.Features.Rates.Handlers.Commands
{
    public class UpdateRateCommandHandler : IRequestHandler<UpdateRateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateRateCommand request, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                await request.RateDto.ValidateRateDto();
                var rate = await _unitOfWork.RateRepository.GetByRateType(request.RateDto.RateType);

                if (rate is null)
                    throw new NotFoundException(nameof(rate), request.RateDto.RateType);

                rate.SetRateInPercentage(request.RateDto.RateInPercentage);

                await _unitOfWork.RateRepository.Update(rate);
                await _unitOfWork.Save();

                return Unit.Value;
            }
        }
    }
}