using MasGlobal.HandsOn.Model.Enums;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MasGlobal.HandsOn.BL.Transverse
{

    /// <summary>
    /// Instrumentation and loggin hanlder
    /// </summary>
    public static class LoggingService
    {
        /// <summary>
        /// Log Exception according Exeption Application bLock EL
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public static bool LogException(Exception exception, ExceptionPolicyEnum policyName)
        {
            try
            {
                IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
                LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
                Logger.SetLogWriter(logWriterFactory.Create(), false);
                ExceptionPolicyFactory factory = new ExceptionPolicyFactory(configurationSource);
                ExceptionPolicy.SetExceptionManager(factory.CreateManager(), false);

                ExceptionPolicy.HandleException(exception, policyName.ToString());

                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Log Event overload for infomration
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="loggingCategory"></param>
        /// <returns></returns>
        public static bool LogInformation(string mensaje, LoggingCategoryEnum loggingCategory)
        {
            return LogEvent(mensaje, TraceEventType.Information, loggingCategory);
        }

        /// <summary>
        /// Log Event overload for warning
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="loggingCategory"></param>
        /// <returns></returns>
        public static bool LogWarning(string mensaje, LoggingCategoryEnum loggingCategory)
        {
            return LogEvent(mensaje, TraceEventType.Warning, loggingCategory);
        }

        /// <summary>
        /// Log Event According logging application Block EL
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="severidad"></param>
        /// <param name="loggingCategory"></param>
        /// <returns></returns>
        public static bool LogEvent(string mensaje, TraceEventType severidad, LoggingCategoryEnum loggingCategory)
        {
            try
            {
                IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
                LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
                Logger.SetLogWriter(logWriterFactory.Create(), false);

                Logger.Write(new LogEntry()
                {
                    Message = mensaje,
                    Categories = new List<string>() { loggingCategory.ToString() },
                    Severity = severidad,

                });


                return true;
            }
            catch(Exception error)
            {

                return false;
            }
        }
    }
}
