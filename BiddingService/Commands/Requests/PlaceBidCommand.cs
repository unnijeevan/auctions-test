using BiddingService.Commands.Responses;
using MediatR;
using System;

namespace BiddingService.Commands.Requests
{
    public class PlaceBidCommand: IRequest<PlaceBidResponse>
    {
        public long UserId { get; set; }
        public decimal Price { get; set; }
        public Guid ItemId { get; set; }
    }
}
