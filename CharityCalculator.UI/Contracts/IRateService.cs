using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharityCalculator.UI.Models;
using CharityCalculator.UI.Services.Base;

namespace CharityCalculator.UI.Contracts
{
    public interface IRateService
    {
        Task<List<RateVM>> GetRates();
        Task<RateVM> GetRate(Guid id);
        Task<Response<int>> CreateRate(RateVM rate);
        Task<Response<int>> UpdateRate(RateVM rate);
        Task<Response<int>> DeleteRate(Guid id);
        Task<decimal> GetDeductibleAmount(DeductibleAmountVM deductibleAmount);
    }
}
