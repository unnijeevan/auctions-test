using BiddingService.Domain;
using System;
using System.Collections.Generic;

namespace BiddingService.Init
{
    internal static class SeedData
    {
        private static Guid ItemId1 = new Guid("6ad5c44d-623f-4bf1-bf6f-b1c2ee6b7350");
        private static Guid ItemId2 = new Guid("50b0670e-7cf7-4acf-a697-7845d5cea43a");
        private static Guid ItemId3 = new Guid("fb6f539f-2b2b-409a-a49e-672c35733d90");
        private static Guid ItemId4 = new Guid("4b509755-3ead-4d0f-a011-a6a02e64e3cd");
        private static Guid ItemId5 = new Guid("b495e2d4-b9d6-4474-993f-f0270b5eb1c9");
        private static Guid ItemId6 = new Guid("dc4b6fdc-19de-449f-92ce-d2c50b0da904");
        private static Guid ItemId7 = new Guid("ac52c941-b313-412e-be46-f345c2ea72b3");
        private static Guid ItemId8 = new Guid("da716ad4-af88-418d-a3b3-8577375c7366");

        internal static IEnumerable<AuctionItem> AuctionItems()
        {
            var dateTimeNow = DateTimeOffset.UtcNow;
            return new List<AuctionItem>()
            {
              new AuctionItem { EndTime = dateTimeNow.AddMinutes(1), ItemId = ItemId1, MinIncrement = 5, Startprice = 20  },
              new AuctionItem { EndTime = dateTimeNow.AddMinutes(12), ItemId = ItemId2, MinIncrement = 15, Startprice = 200  },
              new AuctionItem { EndTime = dateTimeNow.AddMinutes(13), ItemId = ItemId3, MinIncrement = 25, Startprice = 300  },
              new AuctionItem { EndTime = dateTimeNow.AddMinutes(14), ItemId = ItemId4, MinIncrement = 105, Startprice = 2000  },
              new AuctionItem { EndTime = dateTimeNow.AddMinutes(15), ItemId = ItemId5, MinIncrement = 75, Startprice = 2000  },
              new AuctionItem { EndTime = dateTimeNow.AddMinutes(16), ItemId = ItemId6, MinIncrement = 12, Startprice = 400 },
              new AuctionItem { EndTime = dateTimeNow.AddMinutes(17), ItemId = ItemId7, MinIncrement = 15, Startprice = 80  },
              new AuctionItem { EndTime = dateTimeNow.AddMinutes(18), ItemId = ItemId8, MinIncrement = 5, Startprice = 20  }
            };
        }
       
    }
}
