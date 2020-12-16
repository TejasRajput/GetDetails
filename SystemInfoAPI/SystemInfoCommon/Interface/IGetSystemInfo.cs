using System.Collections.Generic;
using System.Threading.Tasks;
using SystemInfoCommon.Model;

namespace SystemInfoCommon.Interface
{
    public interface IGetSystemInfo
    {
        Task<IEnumerable<ItemDetails>> GetSystemInfo(int itemId);

        Task<IEnumerable<Items>> GetItemAsync();
    }
}