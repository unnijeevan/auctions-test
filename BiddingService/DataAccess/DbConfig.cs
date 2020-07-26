using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BiddingService.Domain;

namespace BiddingService.DataAccess
{
    public static class DbConfig
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<BidDbContext>(options =>
            {
                options.UseInMemoryDatabase("BiddingService");
            });
            services.AddScoped<IBidRepository, BidRepository>();
            services.AddScoped<IAuctionItemRepository, AuctionItemRepository>();
            return services;
        }
    }
}
