﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs.EventType;
using CharityCalculator.Application.Features.EventTypes.Requests;
using CharityCalculator.Application.Features.EventTypes.Requests.Commands;
using CharityCalculator.Application.Features.EventTypes.Requests.Queries;
using CharityCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;


namespace CharityCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<EventTypeController>
        [HttpGet]
        public async Task<ActionResult<List<EventTypeDto>>> Get()
        {
            var eventTypesDto = await _mediator.Send(new GetEventTypeListRequest());
            return Ok(eventTypesDto);
        }

        // GET api/<EventTypeController>/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTypeDto>> Get(Guid id)
        {
            var eventTypeDto = await _mediator.Send(new GetEventTypeItemRequest{Id = id});
            return Ok(eventTypeDto);
        }

        // POST api/<EventTypeController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "EventPromoter")]
        public async Task<BaseResponse> Post([FromBody] EventTypeDto eventTypeDto)
        {
            var baseResponse = await _mediator.Send(new CreateEventTypeCommand{EventTypeDto = eventTypeDto});
            return baseResponse;
        }

        // PUT api/<EventTypeController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "EventPromoter")]
        public async Task<ActionResult> Put([FromBody] EventTypeDto eventTypeDto)
        {
            await _mediator.Send(new UpdateEventTypeCommand { EventTypeDto = eventTypeDto });
            return NoContent();

        }

        // DELETE api/<EventTypeController>/guid
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "EventPromoter")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEventTypeCommand { Id = id});
            return NoContent();
        }

        // GET api/<EventTypeController>/GetDonationOptimalSplits
        [HttpGet("GetDonationOptimalSplits")]
        public async Task<ActionResult<List<decimal>>> GetDonationOptimalSplits(DonationOptimalSplitDto donationOptimalSplitDto)
        {
            var optimalSplits = await _mediator.Send(new GetDonationOptimalSplitRequest { DonationOptimalSplitDto = donationOptimalSplitDto });
            return Ok(optimalSplits);
        }
    }
}
