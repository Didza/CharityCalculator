using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.Rates.Requests.Commands;
using CharityCalculator.Application.Responses;
using MediatR;

namespace CharityCalculator.Application.Features.EventTypes.Handlers.Commands
{
    public class CreateRateCommandHandler : IRequestHandler<CreateRateCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async  Task<BaseResponse> Handle(CreateRateCommand request, CancellationToken cancellationToken)
        {
            var newRate = request.RateDto.ToRate();

            var rate = await _unitOfWork.RateRepository.GetByRateType(newRate.RateType);

            if (rate != null)
                return new BaseResponse()
                {
                    Success = true,
                    Message = "Rate Already Exist",
                    Id = rate.Id
                };

            rate = await _unitOfWork.RateRepository.Add(newRate);
            await _unitOfWork.Save();

            return new BaseResponse()
            {
                Success = true,
                Message = "Creation Successful",
                Id = rate.Id
            };

        }
    }
}
