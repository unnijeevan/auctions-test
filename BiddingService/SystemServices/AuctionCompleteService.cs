using BiddingService.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BiddingService.SystemServices
{
    public class AuctionCompleteService : IHostedService, IDisposable
    {
        private readonly ILogger<AuctionCompleteService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer timer;
   
        public AuctionCompleteService(ILogger<AuctionCompleteService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Auction complete Service running.");

            timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(2));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Auction complete Service is stopping.");

            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _auctionItemRepository = scope.ServiceProvider.GetRequiredService<IAuctionItemRepository>();
                var _bidRepository = scope.ServiceProvider.GetRequiredService<IBidRepository>();

                var completedItems = _auctionItemRepository.GetCompletedAuctionsAsync().Result;
                if (completedItems.Any())
                {
                    foreach (var item in completedItems)
                    {
                        var curBid = _bidRepository.GetCurrentBidAsync(item.ItemId).Result;
                        item.BuyerUserId = curBid.UserId;
                        var result = _auctionItemRepository.UpdateItemAsync(item).Result;

                        _logger.LogInformation($"{result.ItemId} Auctioned. Selling Price {curBid.Price}");

                        /*Publish this information to a bus with Sellling Price, Item Id etc */
                    }
                }
            }
            _logger.LogInformation(
                "Auction complete Service is working");
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
