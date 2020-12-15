using System.Collections.Generic;
using System.Threading.Tasks;
using SystemInfoCommon.Model;

namespace SystemInfoCommon.Interface
{
    public interface IGetSystemInfo
    {
        Task<string> GetSystemInfo(string selection);

        Task<IEnumerable<Items>> GetItemAsync();
    }
}