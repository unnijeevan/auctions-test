using BiddingService.Domain;
using BiddingService.Queries.Handlers;
using Moq;
using System;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Xunit;
using BiddingService.Queries.Requests;
using System.Threading;
using BiddingService.Exceptions;

namespace BiddingService.Test
{
    public class GetCurrentBidHandlerTests
    {
        private readonly Mock<IBidRepository> _bidRepository;
        private readonly Mock<IAuctionItemRepository> _auctionItemRepository;
        private readonly GetCurrentBidHandler _getCurrentBidHandler;

        private Guid testItemId1 = new Guid("d1465ab8-834a-4d4a-9b29-8f5fbdac4e0c");
        private Guid testItemId2 = new Guid("2fa34d4f-752e-46ca-9269-68055471fab6");

        public GetCurrentBidHandlerTests()
        {
            _bidRepository = new Mock<IBidRepository>();
            _auctionItemRepository = new Mock<IAuctionItemRepository>();
            _getCurrentBidHandler = new GetCurrentBidHandler(_bidRepository.Object, _auctionItemRepository.Object);
        }

        [Fact]
        public async Task Should_Throw_ItemNotFound_When_Item_Not_InAuction()
        {
            _auctionItemRepository.Setup(ar => ar.GetAsync(testItemId2)).Returns(Task.FromResult<AuctionItem>(null));
            _bidRepository.Setup(br => br.GetCurrentBidAsync(testItemId2)).Returns(Task.FromResult(new Bid()));

            Task handle() => _getCurrentBidHandler.Handle(new GetCurrentBidQuery(testItemId2), CancellationToken.None);

            await Assert.ThrowsAsync<ItemNotFoundException>(handle);
        }

        [Fact]
        public async Task Should_Return_Null_If_No_Bids_Have_Been_Placed()
        {
            _auctionItemRepository.Setup(ar => ar.GetAsync(testItemId1)).Returns(Task.FromResult(new AuctionItem() { ItemId = testItemId1 }));
            _bidRepository.Setup(br => br.GetCurrentBidAsync(testItemId1)).Returns(Task.FromResult<Bid>(null));

            var result = await _getCurrentBidHandler.Handle(new GetCurrentBidQuery(testItemId1), CancellationToken.None);

            Assert.Null(result);
        }

        [Fact]
        public async Task Should_Return_Current_Bid_If_Bid_Had_Been_Placed()
        {
            _auctionItemRepository.Setup(ar => ar.GetAsync(testItemId1)).Returns(Task.FromResult(new AuctionItem() { ItemId = testItemId1 }));
            _bidRepository.Setup(br => br.GetCurrentBidAsync(testItemId1)).Returns(Task.FromResult(new Bid() { Price = 100 }));

            var result = await _getCurrentBidHandler.Handle(new GetCurrentBidQuery(testItemId1), CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(100, result.Price);
        }
    }
}
