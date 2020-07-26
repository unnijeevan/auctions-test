using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemService
{
    public class AuctionCompleteService : IHostedService, IDisposable
    {
        private readonly ILogger<AuctionCompleteService> _logger;
        private Timer _timer;
   
        public AuctionCompleteService(ILogger<AuctionCompleteService> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Auction complete Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Auction complete Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            //Get completed auctions
            // Update the seller id .
            //update item status 
            //send emails 
            _logger.LogInformation(
                "Auction complete Service is working");
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
