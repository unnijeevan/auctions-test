using BiddingService.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace BiddingService.Init
{
    public class BidDbContextSeed
    {
        public async Task SeedAsync(BidDbContext bidDbContext)
        {
            await bidDbContext.Database.EnsureCreatedAsync();
            if (bidDbContext.AuctionItems.Any())
                return;
            await bidDbContext.AuctionItems.AddRangeAsync(SeedData.AuctionItems());
            await bidDbContext.SaveChangesAsync();
        }
    }
}
