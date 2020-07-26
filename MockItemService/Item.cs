using System;

namespace MockItemService
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string  PhotoUrl { get; set; }

        public long SellerId { get; set; }
        public long BuyerId { get; set; }

        public decimal StartPrice { get; set; }
        public decimal MinIncrement { get; set; }

        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }

        public ItemStatus ItemStatus { get; set; }

    }

    public enum ItemStatus
    {
        PendingAuction,
        AuctionStarted,
        AuctionCompleted,
        Cancelled
    }
}
