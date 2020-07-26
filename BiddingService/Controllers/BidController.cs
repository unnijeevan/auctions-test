using System;
using System.Threading.Tasks;
using BiddingService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BiddingService.Controllers
{
    [ApiController]
    [Route("api/bidding/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository _bidRepository;

        public BidController(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBid([FromBody]Bid bid)
        {
            var result = await _bidRepository.AddAsync(bid);
            return Ok(result);
        }

        [HttpGet]
        [Route("getCurrentBid/{itemId?}")]
        public async Task<IActionResult> GetCurrentBid(Guid itemId)
        {
            var result = await _bidRepository.GetCurrentBidAsync(itemId);
            return Ok(result);
        }
    }
}
