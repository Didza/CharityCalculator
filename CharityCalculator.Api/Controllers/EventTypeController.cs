using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Features.EventTypes.Requests;
using CharityCalculator.Application.Features.EventTypes.Requests.Commands;
using CharityCalculator.Application.Features.EventTypes.Requests.Queries;
using CharityCalculator.Application.Responses;
using MediatR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CharityCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<EventTypeController>
        [HttpGet]
        public async Task<List<EventTypeDto>> Get()
        {
            var eventTypes = await _mediator.Send(new GetEventTypeListRequest());
            return eventTypes;
        }

        // GET api/<EventTypeController>/guid
        [HttpGet("{id}")]
        public async Task<EventTypeDto> Get(Guid id)
        {
            var eventType = await _mediator.Send(new GetEventTypeItemRequest{Id = id});
            return eventType;
        }

        // POST api/<EventTypeController>
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody] EventTypeDto eventType)
        {
            var baseResponse = await _mediator.Send(new CreateEventTypeCommand{EventTypeDto = eventType});
            return baseResponse;
        }

        // PUT api/<EventTypeController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EventTypeDto eventType)
        {
            await _mediator.Send(new UpdateEventTypeCommand { EventTypeDto = eventType });
            return NoContent();

        }

        // DELETE api/<EventTypeController>/guid
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEventTypeCommand { Id = id});
            return NoContent();
        }
    }
}
