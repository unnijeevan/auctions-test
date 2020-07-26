using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiddingService.Domain
{
    public interface IAuctionItemRepository
    {
        Task<IEnumerable<AuctionItem>> GetCompletedAuctionsAsync();
        Task<AuctionItem>  GetAsync(Guid itemId);
    }
}
