using System;
using System.Threading.Tasks;

namespace BiddingService.Domain
{
    public interface IBidRepository
    {
        Task<Bid> AddAsync(Bid bid);        
        Task<Bid> GetCurrentBidAsync(Guid itemId);        
    }
}
