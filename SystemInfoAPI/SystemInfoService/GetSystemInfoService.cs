using System.Collections.Generic;
using System.Threading.Tasks;
using SystemInfoCommon.Interface;
using SystemInfoCommon.Model;

namespace SystemInfoService
{
    public class GetSystemInfoService : ISystemInfoService
    {
        public readonly IGetSystemInfo _getSystemInfo;

        public GetSystemInfoService(IGetSystemInfo getSystemInfo)
        {
            _getSystemInfo = getSystemInfo;
        }

        public async Task<IEnumerable<ItemDetails>> SystemProcess(int itemId)
        {
            return await _getSystemInfo.GetSystemInfo(itemId);
        }

        public async Task<IEnumerable<Items>> GetItemAsync()
        {
            return await _getSystemInfo.GetItemAsync();
        }
    }
}