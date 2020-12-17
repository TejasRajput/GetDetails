using SystemInfoCommon.Model;

namespace SystemInfoCommon.Interface
{
    public interface IAuthenticateService
    {
        User Authenticate(string userName, string password);
    }
}