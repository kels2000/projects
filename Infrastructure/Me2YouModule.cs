#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="Me2YouModule.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.WebUI.Me2U.Infrastructure
{
    using log4net;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Web;
    using USFS.Core.Configuration;
    using USFS.Core.Configuration.USFSConfiguration;
    using USFS.Core.Configuration.USFSConfiguration.Implementations;
    using USFS.Core.Data;
    using USFS.Core.Email;
    using USFS.Core.Ninject;
    using USFS.Domain.Me2U.Repositories;
    using USFS.Security.SSO;
    using USFS.Startup;
    using USFS.WebUI.Me2U.Helpers;

    /// <summary>
    /// Handles all of the ninject bindings
    /// </summary>
    public class Me2YouModule : UsfsNinjectModule
    {
        /// <summary>
        /// The category for ADFS SSO. Application name is Me2You
        /// </summary>
        private const string SettingCategory = "Me2U";

        /// <summary>
        /// The realm setting is the URL to get the trusts from. Example: https://sso.unitedshore.com/FederationMetadata/2007-06/FederationMetadata.xml
        /// </summary>
        private const string RealmSetting = "WtRealm";

        /// <summary>
        /// The meta data is the possible return items for ADFS. What kinds of information can be gotten from it
        /// </summary>
        private const string AdfsMetadataSetting = "AdfsMetadata";

        /// <summary>
        /// The connection string for the Huddle database
        /// </summary>
        private string HuddleConnectionString;

        /// <summary>
        /// The logger for log4net
        /// </summary>
        private static ILog Log;

        /// <summary>
        /// Start the ninject binding. Binds all of the required items in the project
        /// </summary>
        protected override void Setup()
        {
            var kernel = Kernel;
            Log = LogManager.GetLogger(typeof(Me2YouModule));
            HuddleConnectionString = ConfigurationHelpers.GetConnectionString("Huddle");

            Log.ErrorFormat("Reading configuration...  . . .   .  .  .");

            USFS.Core.Configuration.Environment currentEnvironment = USFS.Core.Configuration.Environment.GetEnvironment();
            Log.InfoFormat(" Environment: {0}", currentEnvironment);

            if (currentEnvironment == null)
            {
                Log.ErrorFormat("**** Unable to determine the Run Level for application.                     ****");
                Log.ErrorFormat("**** The application relies on the environment variable USFS_RUN_LEVEL to   ****");
                Log.ErrorFormat("**** PRODUCTION or TEST depending on the environment. If this is running    ****");
                Log.ErrorFormat("**** under IIS, reboot the machine after setting the environment variable.  ****");

                throw new ConfigurationErrorsException(" Unable to determine environment run-level. Application in an invalid state and cannot be started. See log for details. ");
            }

            //USFS Bindings
            BindDataRepository(kernel);
            BindEmailService(kernel);
            BindConfigurationService(kernel);
            BindSingleSignOnOnStartup(kernel);

            //Me2You Bindings
            BindPostRepository(kernel);
            BindCategoryRepository(kernel);
            BindUserRepository(kernel);
            BindTicketClaimsRepository(kernel);
            BindEventRepository(kernel);
            BindEmailRepository(kernel);

            //Extra Bindings
            BindHelpers(kernel);
        }

        #region USFS-Bindings
        /// <summary>
        /// Bind the USFS DataRepository to the huddle database
        /// </summary>
        /// <param name="kernel"></param>
        private void BindDataRepository(IKernel kernel)
        {
            kernel.Bind<DataRepository>().ToSelf().WithConstructorArgument("connectionString", HuddleConnectionString);
        }

        /// <summary>
        /// Bind the USFS emailing service
        /// </summary>
        /// <param name="kernel"></param>
        private void BindEmailService(IKernel kernel)
        {
            kernel.Bind<IEmailServices>().To<DBMailerServices>()
                .WithConstructorArgument("profile", "UWSLOSMail");
        }

        /// <summary>
        /// Bind the configuration services to the database
        /// </summary>
        /// <param name="kernel"></param>
        private static void BindConfigurationService(IKernel kernel)
        {
            // Bind services
            kernel.Bind<IConfigurationRepository>().To<DatabaseClientConfigurationRepository>().InSingletonScope()
                .WithConstructorArgument("database", new DataRepository(ConfigurationHelpers.GetConnectionString("Huddle")))
                .WithConstructorArgument("environment", USFS.Core.Configuration.Environment.GetEnvironment());

            kernel.Bind<IConfigurationServices>().To<ConfigurationServices>().InSingletonScope();
        }

        /// <summary>
        /// Binding for the single sign on process
        /// </summary>
        /// <param name="kernel"></param>
        private static void BindSingleSignOnOnStartup(IKernel kernel)
        {
            var configurationService = kernel.Get<IConfigurationServices>();
            string wtrealm = configurationService.GetSetting(SettingCategory, RealmSetting).Value;
            string adfsmetadata = configurationService.GetSetting(SettingCategory, AdfsMetadataSetting).Value;

            kernel.Bind<IUsfsStartup>().To<SingleSignOnStartup>().InSingletonScope()
                .WithConstructorArgument("wtrealm", wtrealm)
                .WithConstructorArgument("adfsMetadata", adfsmetadata);
            kernel.Bind<ISingleSignOnService>().To<SingleSignOnService>().InSingletonScope()
                .WithConstructorArgument("httpContextBase", new HttpContextWrapper(HttpContext.Current));
        }
        #endregion

        #region Me2You-Bindings
        /// <summary>
        /// Bind the post repository to the interface
        /// </summary>
        /// <param name="kernel"></param>
        private void BindPostRepository(IKernel kernel)
        {
            kernel.Bind<IPostRepository>()
                .To<PostRepository>()
                .InSingletonScope()
                .WithConstructorArgument(new DataRepository(HuddleConnectionString));
        }

        /// <summary>
        /// Bind the category repository to the interface
        /// </summary>
        /// <param name="kernel"></param>
        private void BindCategoryRepository(IKernel kernel)
        {
            kernel.Bind<ICategoryRepository>()
                .To<CategoryRepsitory>()
                .InSingletonScope()
                .WithConstructorArgument(new DataRepository(HuddleConnectionString));
        }

        /// <summary>
        /// Bind the user repository to the interface
        /// </summary>
        /// <param name="kernel"></param>
        private void BindUserRepository(IKernel kernel)
        {
            kernel.Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
        }

        /// <summary>
        /// Bind the ticket claims repository to the interface
        /// </summary>
        /// <param name="kernel"></param>
        private void BindTicketClaimsRepository(IKernel kernel)
        {
            kernel.Bind<ITicketClaimsRepository>()
                .To<TicketClaimsRepository>()
                .InSingletonScope()
                .WithConstructorArgument(new DataRepository(HuddleConnectionString));
        }

        /// <summary>
        /// Bind the event repository to the interface
        /// </summary>
        /// <param name="kernel"></param>
        private void BindEventRepository(IKernel kernel)
        {
            kernel.Bind<IEventRepository>()
                .To<EventRepository>()
                .InSingletonScope()
                .WithConstructorArgument(new DataRepository(HuddleConnectionString));
        }

        /// <summary>
        /// Bind the email repository to the interface
        /// </summary>
        /// <param name="kernel"></param>
        private void BindEmailRepository(IKernel kernel)
        {
            kernel.Bind<IEmailRepository>()
                .To<EmailRepository>()
                .InSingletonScope()
                .WithConstructorArgument(new DataRepository(HuddleConnectionString));

        }
        #endregion

        /// <summary>
        /// Verify the setup of the binding. There is no current implementation but it is required from the abstract
        /// </summary>
        protected override void VerifySetup()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Null implementation of required abstract method
        /// </summary>
        public override IEnumerable<Type> DependentModuleTypes { get; } = null;

        /// <summary>
        /// Binds the helper Interfaces to the respective classes
        /// </summary>
        /// <param name="kernel"></param>
        private void BindHelpers(IKernel kernel)
        {
            kernel.Bind<IClaimsHelper>().To<ClaimsHelper>();
            kernel.Bind<ILoggingHelper>().To<LoggingHelper>();
        }
    }
}