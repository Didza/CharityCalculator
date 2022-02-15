using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CharityCalculator.UI.Contracts;
using CharityCalculator.UI.Models;
using CharityCalculator.UI.Services.Base;

namespace CharityCalculator.UI.Services
{
    public class RateService : BaseHttpService, IRateService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public RateService(IMapper mapper, IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
        {
            _httpclient = httpclient;
            _mapper = mapper;
            _localStorageService = localStorageService;
        }

        public async Task<List<RateVM>> GetRates()
        {
            AddBearerToken();
            var rates = await _client.RateAllAsync();
            return _mapper.Map<List<RateVM>>(rates);
        }

        public async Task<RateVM> GetRate(Guid id)
        {
            AddBearerToken();
            var rates = await _client.RateGETAsync(id);
            return _mapper.Map<RateVM>(rates);
        }

        public async Task<Response<Guid>> CreateRate(RateVM rate)
        {
            try
            {
                var response = new Response<Guid>();
                RateDto createRate = _mapper.Map<RateDto>(rate);
                AddBearerToken();
                var apiResponse = await _client.RatePOSTAsync(createRate);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<int>> UpdateRate(RateVM rate)
        {
            try
            {
                RateDto rateDto = _mapper.Map<RateDto>(rate);
                AddBearerToken();
                await _client.RatePUTAsync(rateDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteRate(Guid id)
        {
            try
            {
                AddBearerToken();
                await _client.RateDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<double> GetDeductibleAmount(DeductibleAmountVM deductibleAmount)
        {
            var deductibleAmountDto = _mapper.Map<DeductibleAmountDto>(deductibleAmount);
            AddBearerToken();
            var amountDeductible = await _client.GetDeductibleAmountAsync(deductibleAmountDto);
            return amountDeductible;
        }
    }
}
