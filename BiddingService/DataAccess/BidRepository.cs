using BiddingService.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BiddingService.DataAccess
{
    public class BidRepository : IBidRepository
    {
        private readonly BidDbContext _bidDbContext;

        public BidRepository(BidDbContext bidDbContext)
        {
            _bidDbContext = bidDbContext;
        }

        public async Task<Bid> AddAsync(Bid bid)
        {
            await _bidDbContext.Bids.AddAsync(bid);
            await _bidDbContext.SaveChangesAsync();
            return bid;
        }

        public async Task<Bid> GetCurrentBidAsync(Guid itemId)
        {
            return await _bidDbContext.Bids.OrderByDescending(b => b.BidDateTime)
                .FirstOrDefaultAsync(i => i.ItemId == itemId);
        }
    }
}
