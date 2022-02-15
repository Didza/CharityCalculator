using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharityCalculator.Application.DTOs;
using CharityCalculator.Application.DTOs.Rate;
using CharityCalculator.Application.Extensions;
using CharityCalculator.Application.Features.EventTypes.Requests.Commands;
using CharityCalculator.Application.Features.Rates.Requests.Commands;
using CharityCalculator.Application.Features.Rates.Requests.Queries;
using CharityCalculator.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CharityCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<RateController>
        [HttpGet]
        public async Task<ActionResult<List<RateDto>>> Get()
        {
            var ratesDto = await _mediator.Send(new GetRateListRequest());
            return Ok(ratesDto);
        }

        // GET api/<RateController>/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<RateDto>>  Get(Guid id)
        {
            var rateDto = await _mediator.Send(new GetRateItemRequest { Id = id });
            return Ok(rateDto);
        }

        // POST api/<RateController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseResponse>> Post([FromBody] RateDto rateDto)
        {
            await rateDto.ValidateRateDto();
            var baseResponse = await _mediator.Send(new CreateRateCommand { RateDto = rateDto });
            return Ok(baseResponse);
        }

        // PUT api/<RateController>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put([FromBody] RateDto rateDto)
        {
            await rateDto.ValidateRateDto();
            await _mediator.Send(new UpdateRateCommand { RateDto = rateDto });
            return NoContent();
        }

        // DELETE api/<RateController>/guid
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteRateCommand { Id = id });
            return NoContent();
        }

        // GET: api/<RateController>/GetDeductibleAmount
        [HttpGet("GetDeductibleAmount")]
        public async Task<ActionResult<decimal>> GetDeductibleAmount(DeductibleAmountDto deductibleAmountDto)
        {
            var deductibleAmount = await _mediator.Send(new GetDeductibleAmountRequest{DeductibleAmountDto = deductibleAmountDto});
            return Ok(deductibleAmount);
        }
    }
}
