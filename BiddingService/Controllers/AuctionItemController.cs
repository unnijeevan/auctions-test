using System.Threading.Tasks;
using BiddingService.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BiddingService.Controllers
{
    [Route("api/bidding/[controller]")]
    [ApiController]
    public class AuctionItemController : ControllerBase
    {
        private readonly IAuctionItemRepository _auctionItemRepository;

        public AuctionItemController(IAuctionItemRepository auctionItemRepository)
        {
            _auctionItemRepository = auctionItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompletedAuctions()
        {
            var result = await _auctionItemRepository.GetCompletedAuctionsAsync();
            return Ok(result);
        }
    }
}
