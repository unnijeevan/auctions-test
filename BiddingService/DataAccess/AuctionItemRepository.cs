﻿using BiddingService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BiddingService.DataAccess
{
    public class AuctionItemRepository : IAuctionItemRepository
    {
        private readonly BidDbContext _bidDbContext;

        public AuctionItemRepository(BidDbContext bidDbContext)
        {
            _bidDbContext = bidDbContext;
        }

        public async Task<AuctionItem> GetAsync(Guid itemId)
        {
            return await _bidDbContext.AuctionItems.SingleOrDefaultAsync(i => i.ItemId == itemId);
        }

        public async Task<IEnumerable<AuctionItem>> GetCompletedAuctionsAsync()
        {
            return await _bidDbContext.AuctionItems.Where(a => a.EndTime <= DateTimeOffset.UtcNow
            && !a.BuyerUserId.HasValue
            && a.Bids.Any()).ToListAsync();
        }

        public async Task<AuctionItem> UpdateItemAsync(AuctionItem item)
        {
            var dbItem = await _bidDbContext.AuctionItems.SingleOrDefaultAsync(i => i.ItemId == item.ItemId);
            dbItem.BuyerUserId = item.BuyerUserId;
            _bidDbContext.Entry(dbItem).State = EntityState.Modified;
            await _bidDbContext.SaveChangesAsync();
            return dbItem;
        }
    }
}
