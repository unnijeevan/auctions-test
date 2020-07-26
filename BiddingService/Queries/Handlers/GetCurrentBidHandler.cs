using BiddingService.DataAccess;
using BiddingService.Domain;
using BiddingService.Exceptions;
using BiddingService.Queries.Requests;
using BiddingService.Queries.Responses;
using MediatR;
using Microsoft.AspNetCore.Server.IIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BiddingService.Queries.Handlers
{
    public class GetCurrentBidHandler : IRequestHandler<GetCurrentBidQuery, GetCurrentBidResponse>
    {
        private readonly IBidRepository _bidRepository;
        private readonly IAuctionItemRepository _auctionItemRepository;

        public GetCurrentBidHandler(IBidRepository bidRepository, IAuctionItemRepository auctionItemRepository)
        {
            _bidRepository = bidRepository;
            _auctionItemRepository = auctionItemRepository;
        }

        public async Task<GetCurrentBidResponse> Handle(GetCurrentBidQuery request, CancellationToken cancellationToken)
        {
            var item = await _auctionItemRepository.GetAsync(request.ItemId);
            if (item == null)
                throw new ItemNotFoundException(new Exception($"{request.ItemId} not in auction"));

            var result = await _bidRepository.GetCurrentBidAsync(request.ItemId);
            return result != null ? new GetCurrentBidResponse { Id = result.Id, Price = result.Price, UserId = result.UserId } : null;
        }
    }
}
