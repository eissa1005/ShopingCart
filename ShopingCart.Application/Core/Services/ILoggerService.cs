
using ShopingCart.Domain;
using ShopingCart.Domain.Core.Models;

namespace ShopingCart.Application.Core.Services
{
    public interface ILoggerService : IBaseEntity 
    {
        void LogError(string errorMessage);
        void LogError(string errorMessage, params object[] args);
        void LogError(Exception exception, string errorMessage, params object[] args);
        void LogError(Exception exception , string errorMessage);
        void LogException(Exception ex);
        void LogInfo(string infoMeesage);
        void LogInfo(string infoMeesage,params object[] args);
    }
}
