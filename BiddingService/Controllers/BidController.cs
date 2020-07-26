using System;
using System.Threading.Tasks;
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
        private readonly IBidRepository _bidRepository;
        private readonly IMediator _mediator;

        public BidController(IBidRepository bidRepository, IMediator mediator)
        {
            _bidRepository = bidRepository;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("place-bid")]
        public async Task<IActionResult> PlaceBid([FromBody]Bid bid)
        {
            var result = await _bidRepository.AddAsync(bid);
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
