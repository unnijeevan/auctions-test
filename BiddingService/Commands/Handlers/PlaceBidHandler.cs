using BiddingService.Commands.Requests;
using BiddingService.Commands.Responses;
using BiddingService.Domain;
using BiddingService.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BiddingService.Commands.Handlers
{
    public class PlaceBidHandler : IRequestHandler<PlaceBidCommand, PlaceBidResponse>
    {
        private readonly IBidRepository _bidRepository;
        private readonly IAuctionItemRepository _auctionItemRepository;

        public PlaceBidHandler(IBidRepository bidRepository, IAuctionItemRepository auctionItemRepository)
        {
            _bidRepository = bidRepository;
            _auctionItemRepository = auctionItemRepository;
        }

        public async Task<PlaceBidResponse> Handle(PlaceBidCommand request, CancellationToken cancellationToken)
        {
            var item = await _auctionItemRepository.GetAsync(request.ItemId);

            if (item == null)
                throw new ItemNotFoundException(new Exception($"{request.ItemId} not in auction"));

            if (item.EndTime <= DateTimeOffset.UtcNow)
                throw new BiddingEndedException(new Exception($"{request.ItemId} bidding ended"));

            if (item.SellerUserId == request.UserId)
                throw new SellerCannotBidOnItem(new Exception($"{request.UserId} seller bidding on his item"));

            if(request.Price < item.Startprice)
                throw new BidLowerThanStartPriceException(new Exception($"{request.Price} lower than start price {item.Startprice}"));

            var curBid = await _bidRepository.GetCurrentBidAsync(request.ItemId);

            if(curBid != null)
            {
                if(curBid.Price >= request.Price)
                    throw new BidLowerThanCurrentBidException(new Exception($"{request.Price} lower than current bid"));

                var increment = request.Price - curBid.Price;
                if(increment < item.MinIncrement)
                    throw new BidIncementLessThanMinimumException(new Exception($"{increment} lower than minimum {item.MinIncrement}"));
            }

            var result = await _bidRepository.AddAsync(new Bid()
            {
                BidDateTime = DateTimeOffset.UtcNow,
                ItemId = request.ItemId,
                UserId = request.UserId,
                Price = request.Price
            });
            return new PlaceBidResponse() { Id = result.Id };
        }
    }
}
