using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemInfoCommon.Interface;
using SystemInfoCommon.Model;

namespace SystemInfoRepo
{
    public class GetSystemInfoRepo : IGetSystemInfo
    {
        public async Task<string> GetSystemInfo(string selection)
        {
            var message = "Data done";
            return message;
        }

        public async Task<IEnumerable<Items>> GetItemAsync()
        {
            var Result = new List<Items>
            {
                new Items
                {
                    Id = 1,
                    ModelNumber = "D123",
                    Name = "Laptop",
                    Price = 12000
                },
                new Items
                {
                    Id = 2,
                    ModelNumber = "D111",
                    Name = "Head phone",
                    Price = 1900
                },
                new Items
                {
                    Id = 3,
                    ModelNumber = "D222",
                    Name = "Graphics Card",
                    Price = 2500
                }
            };

            return Result;
        }
    }
}