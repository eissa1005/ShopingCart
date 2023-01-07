
namespace ShopingCart.Application.Core.Services
{
    public interface ILoggerService
    {
        void LogError(string errorMessage);
        void LogError(string errorMessage, params object[] args);
        void LogException(Exception ex);
        void LogInfo(string infoMeesage);
        void LogInfo(string infoMeesage,params object[] args);
    }
}
