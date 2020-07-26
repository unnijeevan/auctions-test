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
using BiddingService.Commands.Requests;
using BiddingService.Commands.Handlers;

namespace BiddingService.Test
{
    public class PlaceBidHandlerTests
    {
        private readonly Mock<IBidRepository> _bidRepository;
        private readonly Mock<IAuctionItemRepository> _auctionItemRepository;
        private readonly PlaceBidHandler _placeBidHandler;

        private Guid testItemId1 = new Guid("d1465ab8-834a-4d4a-9b29-8f5fbdac4e0c");
        private Guid testItemId2 = new Guid("2fa34d4f-752e-46ca-9269-68055471fab6");

        private PlaceBidCommand testCommand;
        private AuctionItem testAuctionItem;

        public PlaceBidHandlerTests()
        {
            _bidRepository = new Mock<IBidRepository>();
            _auctionItemRepository = new Mock<IAuctionItemRepository>();
            _placeBidHandler = new PlaceBidHandler(_bidRepository.Object, _auctionItemRepository.Object);
            testCommand = new PlaceBidCommand()
            {
                UserId = 1,                
                Price = 120,
                ItemId = testItemId1
            };

            testAuctionItem = new AuctionItem()
            {
                ItemId = testItemId1,
                MinIncrement = 20,
                Startprice = 50,
                SellerUserId = 2,
                EndTime = DateTimeOffset.UtcNow.AddHours(1)
            };
        }

        [Fact]
        public async Task Should_Throw_ItemNotFound_When_Item_Not_InAuction()
        {
            _auctionItemRepository.Setup(ar => ar.GetAsync(testItemId2)).Returns(Task.FromResult<AuctionItem>(null));

            Task handle() => _placeBidHandler.Handle(new PlaceBidCommand() { ItemId = testItemId2 }, CancellationToken.None);

            await Assert.ThrowsAsync<ItemNotFoundException>(handle);
        }

        [Fact]
        public async Task Should_Throw_When_Auction_Time_Ended()
        {
            testAuctionItem.EndTime = DateTimeOffset.UtcNow.AddMinutes(-1);
            _auctionItemRepository.Setup(ar => ar.GetAsync(testItemId1)).Returns(Task.FromResult(testAuctionItem));
            
            Task handle() => _placeBidHandler.Handle(testCommand, CancellationToken.None);

            await Assert.ThrowsAsync<BiddingEndedException>(handle);
        }

        [Fact]
        public async Task Should_Throw_When_Seller_Bids_OnItem()
        {
            testAuctionItem.SellerUserId = 2;
            testCommand.UserId = 2;
            _auctionItemRepository.Setup(ar => ar.GetAsync(testItemId1)).Returns(Task.FromResult(testAuctionItem));

            Task handle() => _placeBidHandler.Handle(testCommand, CancellationToken.None);

            await Assert.ThrowsAsync<SellerCannotBidOnItem>(handle);
        }

        [Fact]
        public async Task Should_Throw_When_Bid_Less_Than_Start_Price()
        {
            testAuctionItem.Startprice = 50;
            testCommand.Price = 20;
            _auctionItemRepository.Setup(ar => ar.GetAsync(testItemId1)).Returns(Task.FromResult(testAuctionItem));

            Task handle() => _placeBidHandler.Handle(testCommand, CancellationToken.None);

            await Assert.ThrowsAsync<BidLowerThanStartPriceException>(handle);
        }

        [Fact]
        public async Task Should_Throw_When_Bid_Less_Than_Current_Bid()
        {
            testCommand.Price = 90;
            _auctionItemRepository.Setup(ar => ar.GetAsync(testItemId1)).Returns(Task.FromResult(testAuctionItem));
            _bidRepository.Setup(br => br.GetCurrentBidAsync(testItemId1)).Returns(Task.FromResult(new Bid() { Price = 100 }));

            Task handle() => _placeBidHandler.Handle(testCommand, CancellationToken.None);

            await Assert.ThrowsAsync<BidLowerThanCurrentBidException>(handle);
        }

        [Fact]
        public async Task Should_Throw_When_Bid_Increment_Less_Than_Minimum_Increment()
        {
            testAuctionItem.MinIncrement = 50;
            testCommand.Price = 110;
            _auctionItemRepository.Setup(ar => ar.GetAsync(testItemId1)).Returns(Task.FromResult(testAuctionItem));
            _bidRepository.Setup(br => br.GetCurrentBidAsync(testItemId1)).Returns(Task.FromResult(new Bid() { Price = 100 }));

            Task handle() => _placeBidHandler.Handle(testCommand, CancellationToken.None);

            await Assert.ThrowsAsync<BidIncementLessThanMinimumException>(handle);
        }

    }
}
