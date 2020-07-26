using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingService.Queries.Responses
{
    public class GetCurrentBidResponse
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public decimal Price { get; set; }
    }
}
