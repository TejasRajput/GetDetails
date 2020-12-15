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
        public async Task<string> SystemProcess(string selectedItem)
        {
            return await _getSystemInfo.GetSystemInfo(selectedItem);
        }

        public async Task<IEnumerable<Items>> GetItemAsync()
        {
            return await _getSystemInfo.GetItemAsync();
        }
    }
}