using NLog;
using NLog.Web;
using ShopingCart.Application.Core.Services;

namespace ShopingCart.Infrastructure.Services
{
    public class LoggerService : ILoggerService
    {
        NLog.Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        public void LogError(string errorMessage)
        {
            logger.Error(errorMessage);
            
        }
        public void LogError(string errorMessage, params object[] args)
        {
            logger.Error(errorMessage, args);
        }
        public void LogError(Exception exception, string errorMessage)
        {
            logger.Error(exception, errorMessage);
        }
        public void LogError(Exception exception , string errorMessage, params object[] args)
        {
            logger.Error(exception,errorMessage, args);
        }
        public void LogException(Exception ex)
        {
            logger.Error(ex);
        }

        public void LogInfo(string infoMeesage)
        {
            logger.Info(infoMeesage);
        }

        public void LogInfo(string infoMeesage, params object[] args)
        {
            logger.Info(infoMeesage, args);
        }
    }
}
