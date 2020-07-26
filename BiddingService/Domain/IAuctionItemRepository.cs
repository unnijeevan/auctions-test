using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiddingService.Domain
{
    public interface IAuctionItemRepository
    {
        Task<IEnumerable<AuctionItem>> GetCompletedAuctionsAsync();
    }
}
