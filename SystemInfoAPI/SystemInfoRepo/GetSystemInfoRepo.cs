using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemInfoCommon.Interface;
using SystemInfoCommon.Model;

namespace SystemInfoRepo
{
    public class GetSystemInfoRepo : IGetSystemInfo
    {
        private readonly List<ItemDetails> _itemDetailList = new List<ItemDetails>
        {
            new ItemDetails
            {
                Id = 1,
                ItemId = 1,
                Configuration = "2000 Tb hard disk, 8 gb ram",
                Brand = "Dell",
                Details = "7th generation",
                Memory = "2 Tb + 8 Gb ",
                Price = 12000
            },
            new ItemDetails
            {
                Id = 1,
                ItemId = 1,
                Configuration = "1 Tb hard disk, 4 gb ram",
                Brand = "LENOVO",
                Details = "5th generation",
                Memory = "1 Tb + 4 Gb ",
                Price = 10000
            },
            new ItemDetails
            {
                Id = 2,
                ItemId = 2,
                Brand = "BOATS",
                Configuration = "doubly sound",
                Details = "Power by boats",
                Memory = "521kb",
                Price = 8000
            },
            new ItemDetails
            {
                Id = 3,
                ItemId = 3,
                Brand = "Nvidia",
                Configuration = "HD",
                Details = "HD quality",
                Memory = "2 Tb + 8 Gb ",
                Price = 15000
            },
            new ItemDetails
            {
                Id = 4,
                ItemId = 3,
                Brand = "AMD",
                Configuration = "Gaming",
                Details = "for gaming",
                Memory = "2 Tb + 8 Gb ",
                Price = 1222
            },
            new ItemDetails
            {
                Id = 5,
                ItemId = 3,
                Brand = "dell",
                Configuration = "for gaming and movie",
                Details = "game + movie",
                Memory = "0000",
                Price = 1000
            }
        };

        private readonly List<Items> _itemList = new List<Items>
        {
            new Items
            {
                Id = 1,
                ModelNumber = "D123",
                Name = "Laptop"
            },
            new Items
            {
                Id = 2,
                ModelNumber = "D111",
                Name = "Head phone"
            },
            new Items
            {
                Id = 3,
                ModelNumber = "D222",
                Name = "Graphics Card"
            }
        };

        public async Task<IEnumerable<ItemDetails>> GetSystemInfo(int itemId)
        {
            var result = _itemDetailList.Where(x => x.ItemId == itemId).ToList();
            return result;
        }

        public async Task<IEnumerable<Items>> GetItemAsync()
        {
            var result = _itemList.ToList();

            return result;
        }
    }
}