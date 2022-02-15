using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CharityCalculator.UI.Contracts;
using CharityCalculator.UI.Models;
using CharityCalculator.UI.Services.Base;

namespace CharityCalculator.UI.Services
{
    public class EventTypeService : BaseHttpService, IEventTypeService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public EventTypeService(IMapper mapper, IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<List<EventTypeVM>> GetEventTypes()
        {
            AddBearerToken();
            var eventTypes = await _client.EventTypeAllAsync();
            return _mapper.Map<List<EventTypeVM>>(eventTypes);
        }

        public async Task<EventTypeVM> GetEventType(Guid id)
        {
            AddBearerToken();
            var eventType = await _client.EventTypeGETAsync(id);
            return _mapper.Map<EventTypeVM>(eventType);
        }

        public async Task<Response<Guid>> CreateEventType(EventTypeVM eventType)
        {
            try
            {
                var response = new Response<Guid>();
                EventTypeDto createLeaveType = _mapper.Map<EventTypeDto>(eventType);
                AddBearerToken();
                var apiResponse = await _client.EventTypePOSTAsync(createLeaveType);
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

        public async Task<Response<int>> UpdateEventType(EventTypeVM eventType)
        {
            try
            {
                EventTypeDto eventTypeDto = _mapper.Map<EventTypeDto>(eventType);
                AddBearerToken();
                await _client.EventTypePUTAsync(eventTypeDto);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteEventType(Guid id)
        {
            try
            {
                AddBearerToken();
                await _client.EventTypeDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ICollection<double>> GetDonationOptimalSplits(DonationOptimalSplitVM donationOptimalSplit)
        {
            var donationOptimalSplitDto = _mapper.Map<DonationOptimalSplitDto>(donationOptimalSplit);
            AddBearerToken();
            var eventType = await _client.GetDonationOptimalSplitsAsync(donationOptimalSplitDto);
            return eventType;
        }
    }
}
