using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockItemService.Controllers
{
    internal static class MockItems
    {
        private static Guid Id1 = new Guid("6ad5c44d-623f-4bf1-bf6f-b1c2ee6b7350");
        private static Guid Id2 = new Guid("50b0670e-7cf7-4acf-a697-7845d5cea43a");
        private static Guid Id3 = new Guid("fb6f539f-2b2b-409a-a49e-672c35733d90");
        private static Guid Id4 = new Guid("4b509755-3ead-4d0f-a011-a6a02e64e3cd");
        private static Guid Id5 = new Guid("b495e2d4-b9d6-4474-993f-f0270b5eb1c9");
        private static Guid Id6 = new Guid("dc4b6fdc-19de-449f-92ce-d2c50b0da904");
        private static Guid Id7 = new Guid("ac52c941-b313-412e-be46-f345c2ea72b3");
        private static Guid Id8 = new Guid("da716ad4-af88-418d-a3b3-8577375c7366");

        internal static IEnumerable<Item> Get()
        {
            var dateTimeNow = DateTimeOffset.UtcNow;

            return new List<Item>()
            {
              new Item {
                  EndTime = dateTimeNow.AddMinutes(1),
                  StartTime = dateTimeNow.AddHours(-1),
                  Id = Id1,
                  MinIncrement = 5,
                  StartPrice = 20,
                  PhotoUrl = "https://www.kmart.com.au/wcsstore/Kmart/images/ncatalog/f/3/42863823-1-f.jpg",
                  Title = "Medium Resistance training Kit",
                  Description ="Medium Resistance training Kit Description"
              },
                 new Item {
                  EndTime = dateTimeNow.AddMinutes(1),
                  StartTime = dateTimeNow.AddHours(-2),
                  Id = Id2,
                  MinIncrement = 15,
                  StartPrice = 200,
                  PhotoUrl = "https://www.kmart.com.au/wcsstore/Kmart/images/ncatalog/f/7/42711247-1-f.jpg",
                  Title = "Action Camera High Definition",
                  Description ="Action Camera High Definition description"
              },
                    new Item {
                  EndTime = dateTimeNow.AddMinutes(1),
                  StartTime = dateTimeNow.AddHours(-1),
                  Id = Id3,
                  MinIncrement = 25,
                  StartPrice = 300,
                  PhotoUrl = "https://www.kmart.com.au/wcsstore/Kmart/images/ncatalog/f/8/42913078-1-f.jpg",
                  Title = "18 Megapixel Digital Camera",
                  Description ="18 Megapixel Digital Camera description"
              },
                       new Item {
                  EndTime = dateTimeNow.AddMinutes(1),
                  StartTime = dateTimeNow.AddHours(-1),
                  Id = Id4,
                  MinIncrement = 105,
                  StartPrice = 2000,
                  PhotoUrl = "https://www.kmart.com.au/wcsstore/Kmart/images/ncatalog/f/0/42829300-1-f.jpg",
                  Title = "Gaming Headset",
                  Description ="Gaming Headset description"
              },
                          new Item {
                  EndTime = dateTimeNow.AddMinutes(1),
                  StartTime = dateTimeNow.AddHours(-1),
                  Id = Id5,
                  MinIncrement = 75,
                  StartPrice = 2000,
                  PhotoUrl = "https://cdn0.woolworths.media/content/wowproductimages/medium/233155.jpg",
                  Title = "Apple & Cinamon Muffin",
                  Description ="Apple & Cinamon Muffin Description"
              },
                             new Item {
                  EndTime = dateTimeNow.AddMinutes(1),
                  StartTime = dateTimeNow.AddHours(-1),
                  Id = Id6,
                  MinIncrement = 12,
                  StartPrice = 400,
                  PhotoUrl = "https://www.kmart.com.au/wcsstore/Kmart/images/ncatalog/f/5/42483915-1-f.jpg",
                  Title = "70 cm Hard case",
                  Description ="70cm Hard case description"
              },
                                new Item {
                  EndTime = dateTimeNow.AddMinutes(7),
                  StartTime = dateTimeNow.AddHours(-1),
                  Id = Id7,
                  MinIncrement = 15,
                  StartPrice = 80,
                  PhotoUrl = "https://www.kmart.com.au/wcsstore/Kmart/images/ncatalog/f/8/42735878-1-f.jpg",
                  Title = "Hand Vaccum",
                  Description ="Hand Vaccum Description"
              },
                                   new Item {
                  EndTime = dateTimeNow.AddMinutes(11),
                  StartTime = dateTimeNow.AddHours(-9),
                  Id = Id8,
                  MinIncrement = 5,
                  StartPrice = 20,
                  PhotoUrl = "https://www.kmart.com.au/wcsstore/Kmart/images/ncatalog/f/9/42625179-1-f.jpg",
                  Title = "Bluetooth Tower Speaker with Lights",
                  Description ="Bluetooth Tower Speaker with Lights description"
              }

            };
        }
    }
}
