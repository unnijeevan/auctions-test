using BiddingService.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BiddingService.Init
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<BidDbContext>();
                new BidDbContextSeed().SeedAsync(context).Wait();                
            }
        }
    }
}
