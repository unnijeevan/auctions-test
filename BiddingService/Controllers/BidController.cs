using System;
using System.Threading.Tasks;
using BiddingService.Commands.Requests;
using BiddingService.Domain;
using BiddingService.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BiddingService.Controllers
{
    [ApiController]
    [Route("api/bidding/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BidController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("place-bid")]
        public async Task<IActionResult> PlaceBid([FromBody]PlaceBidCommand bidCommand)
        {
            var result = await _mediator.Send(bidCommand);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-current-bid/{itemId?}")]
        public async Task<IActionResult> GetCurrentBid(Guid itemId)
        {
            var result = await _mediator.Send(new GetCurrentBidQuery(itemId));
            return Ok(result);
        }
    }
}
