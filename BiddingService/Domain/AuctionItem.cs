using System;
using System.Collections.Generic;

namespace BiddingService.Domain
{
    public class AuctionItem
    {
        public Guid ItemId { get; set; }
        public long? BuyerUserId { get; set; }
        public decimal Startprice { get; set; }
        public decimal  MinIncrement { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }

    }
}
