using BiddingService.DataAccess.Configurations;
using BiddingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BiddingService.DataAccess
{
    public class BidDbContext: DbContext
    {
        public BidDbContext(DbContextOptions<BidDbContext> options) : base(options)
        { }

        public DbSet<Bid> Bids { get; set; }
        public DbSet<AuctionItem> AuctionItems { get; set; }      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BidConfiguration());
            modelBuilder.ApplyConfiguration(new AuctionItemConfiguration());           
        }
    }
}
