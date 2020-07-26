using BiddingService.Queries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingService.Queries.Requests
{
    public class GetCurrentBidQuery: IRequest<GetCurrentBidResponse>
    {
        public GetCurrentBidQuery(Guid itemId)
        {
            this.ItemId = itemId;
        }

        public Guid ItemId { get; }
    }
}
