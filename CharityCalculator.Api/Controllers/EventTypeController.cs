using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Features.EventTypes.Requests;
using CharityCalculator.Application.Features.EventTypes.Requests.Queries;
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

        // GET api/<EventTypeController>/5
        [HttpGet("{id}")]
        public async Task<EventTypeDto> Get(Guid id)
        {
            var eventType = await _mediator.Send(new GetEventTypeItemRequest{Id = id});
            return eventType;
        }

        // POST api/<EventTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
