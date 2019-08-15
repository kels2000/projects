#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="United Shore Financial Services LLC.">
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
    using Ninject;
    using Ninject.Web.Common.WebHost;
    using System.Net;
    using System.Security.Claims;
    using System.Web.Helpers;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using USFS.Core.Ninject;
    using USFS.WebUI.Me2U.Infrastructure;

    /// <summary>
    /// Responsible for providing the application with all the necessary items at startup
    /// </summary>
    public class MvcApplication : NinjectHttpApplication
    {
        /// <summary>
        /// Registers everything as the application starts
        /// </summary>
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimsIdentity.DefaultNameClaimType;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HealthCheckConfig.RegisterDependencies();
        }

        /// <summary>
        /// Creates the kernel
        /// </summary>
        /// <returns></returns>
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load<CoreModule>();
            kernel.Load<Me2YouModule>();
            return kernel;
        }
    }
}