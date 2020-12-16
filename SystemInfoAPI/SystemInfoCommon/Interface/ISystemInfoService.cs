using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemInfoCommon.Model;

namespace SystemInfoCommon.Interface
{
   public interface ISystemInfoService
    {
        Task<IEnumerable<ItemDetails>> SystemProcess(int itemId);

        Task<IEnumerable<Items>> GetItemAsync();

    }
}
