using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MPS.Shared.Extensions
{
    /// <summary>
    /// Defines extension methods for ILogger 
    /// </summary>
    public static class LoggerExtension
    {
        /// <summary>
        /// Groups logging message with controller & action name
        /// </summary>
        /// <param name="logger">The logger instance</param>
        /// <param name="controllerName">The controller for which the request was raised</param>
        /// <param name="actionMethod">The request for action method to be invoked</param>
        /// <returns></returns>
        public static IDisposable BeginScope(this ILogger logger, string controllerName, string actionMethod)
        {
            return logger.BeginScope(
                new Dictionary<string, object> {
                    {"Controller", controllerName},
                    {"Action", actionMethod }
                });
        }

        public static void LogRequest(this ILogger logger, object request)
        {
            logger.LogDebug("Request recieved: {Request}.", JsonConvert.SerializeObject(request));
            logger.LogInformation("Processing request.");
        }

        public static void LogReponse(this ILogger logger, object response)
        {
            logger.LogDebug("Response: {Response}.", JsonConvert.SerializeObject(response));
            logger.LogInformation("Request processed.");
        }
    }
}
