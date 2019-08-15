#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="LoggingHelper.cs" company="United Shore Financial Services LLC.">
//     Copyright &copy; United Shore Financial Services Inc.
// 
//     Copyright in the application source code, and in the information and
//     material therein and in their arrangement, is owned by United Shore Financial Services LLC.
//     unless otherwise indicated.
// 
//     You shall not remove or obscure any copyright, trademark or other notices.
//     You may not copy, republish, redistribute, transmit, participate in the
//     transmission of, create derivatives of, alter edit or exploit in any
//     manner any material including by storage on retrieval systems, without the
//     express written permission of United Shore Financial Services LLC.
// </copyright>
//------------------------------------------------------------------------------------------

#endregion

namespace USFS.WebUI.Me2U.Helpers
{
    using System;
    using USFS.Core.Configuration.USFSConfiguration;

    /// <summary>
    /// the logging helper
    /// </summary>
    public class LoggingHelper : ILoggingHelper
    {
        /// <summary>
        /// the configuration service
        /// </summary>
        private readonly IConfigurationServices configurationServices;

        /// <summary>
        /// the constructor for the logging helper
        /// </summary>
        /// <param name="configurationServices">the configuration service</param>
        public LoggingHelper(IConfigurationServices configurationServices)
        {
            this.configurationServices = configurationServices;
        }

        /// <summary>
        /// Logs the failed to authenticate error
        /// </summary>
        public void LogAuthenticateError(Type declaringType, string userLogin)
        {
            log4net.GlobalContext.Properties["LogName"] = configurationServices.GetSetting("Me2U", "logEnvironment").Value;
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(declaringType);
            log.Error("If the Failed to Authenticate Screen in Me 2 You is reached it means that " + userLogin + " Adfs Claim is missing the Name Id.");
        }
    }
}