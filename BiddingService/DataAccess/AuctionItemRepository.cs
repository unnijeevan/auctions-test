using BiddingService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BiddingService.DataAccess
{
    public class AuctionItemRepository : IAuctionItemRepository
    {
        private readonly BidDbContext _bidDbContext;

        public AuctionItemRepository(BidDbContext bidDbContext)
        {
            _bidDbContext = bidDbContext;
        }

        public async Task<IEnumerable<AuctionItem>> GetCompletedAuctionsAsync()
        {
            return await _bidDbContext.AuctionItems.Where(a => a.EndTime <= DateTimeOffset.UtcNow
            && !a.BuyerUserId.HasValue
            && a.Bids.Any()).ToListAsync();
        }
    }
}
