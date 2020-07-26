using BiddingService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiddingService.DataAccess.Configurations
{
    public class AuctionItemConfiguration : IEntityTypeConfiguration<AuctionItem>
    {
        public void Configure(EntityTypeBuilder<AuctionItem> builder)
        {
            builder.ToTable("AuctionItems");
            
            builder.HasKey(p => p.ItemId);

            builder.Property(p => p.Startprice).IsRequired();
            builder.Property(p => p.EndTime).IsRequired();
            builder.Property(p => p.MinIncrement).IsRequired();

            builder.HasMany(p => p.Bids).WithOne(p => p.Item).HasForeignKey(f => f.ItemId);      
        }
    }
}
