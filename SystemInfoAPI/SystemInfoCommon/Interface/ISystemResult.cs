using System.Threading.Tasks;

namespace SystemInfoCommon.Interface
{
    public interface ISystemResult
    {
        Task<string> Result();
    }
}