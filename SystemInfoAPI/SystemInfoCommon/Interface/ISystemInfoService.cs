using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemInfoCommon.Model;

namespace SystemInfoCommon.Interface
{
   public interface ISystemInfoService
    {
        Task<string> SystemProcess(string selectedItem);

        Task<IEnumerable<Items>> GetItemAsync();

    }
}
