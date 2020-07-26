using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingService.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(Exception ex) :
            base($"Auction Item not found", ex)
        {
        }
    }
    public class BiddingEndedException : Exception
    {
        public BiddingEndedException(Exception ex) :
            base($"Bidding for this item already ended", ex)
        {
        }
    }
    public class BidLowerThanCurrentBidException : Exception
    {
        public BidLowerThanCurrentBidException(Exception ex) :
            base($"The bidding amount is lower than the current bid", ex)
        {
        }
    }

    public class BidIncementLessThanMinimumException : Exception
    {
        public BidIncementLessThanMinimumException(Exception ex) :
            base($"The bidding increment is less than the minimum required for this auction item", ex)
        {
        }
    }

    public class SellerCannotBidOnItem : Exception
    {
        public SellerCannotBidOnItem(Exception ex) :
            base($"Seller cannot bid on their item", ex)
        {
        }
    }
}