using System;

namespace BiddingService.Domain
{
    public class Bid
    {
        public long Id { get; set; }
        public DateTimeOffset BidDateTime { get; set; }
        public long UserId { get; set; }
        public decimal Price { get; set; }
        public Guid ItemId { get; set; }
        public AuctionItem Item { get; set; }
    }
}
