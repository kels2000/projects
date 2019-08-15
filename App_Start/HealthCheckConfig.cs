#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="HealthCheckConfig.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.WebUI.Me2U
{
    using System;
    using Microsoft.AspNet.HealthChecks;
    using Microsoft.Extensions.HealthChecks;
    using USFS.Core.Configuration;

    public class HealthCheckConfig
    {
        /// <summary>
        /// the dependency registrar
        /// </summary>
        public static void RegisterDependencies()
        {
            var maxMemory = 2500000000000;

            HealthCheckHandler.Timeout = TimeSpan.FromSeconds(3);

            GlobalHealthChecks.Build(builder =>
                builder
                    .WithDefaultCacheDuration(TimeSpan.FromMinutes(1))
                    .AddHealthCheckGroup(
                        "Basic",
                        group =>
                            group
                                .AddPrivateMemorySizeCheck(maxMemory)
                                .AddVirtualMemorySizeCheck(maxMemory)
                                .AddWorkingSetCheck(maxMemory))
                    .AddHealthCheckGroup(
                        "Databases",
                        group =>
                            group
                                .AddSqlCheck("Destiny", ConfigurationHelpers.GetConnectionString("Destiny"))
                                .AddSqlCheck("SecurityService", ConfigurationHelpers.GetConnectionString("SecurityService")))
            );
        }
    }
}