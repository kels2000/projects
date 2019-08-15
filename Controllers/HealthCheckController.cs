#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="HealthCheckController.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.WebUI.Me2U.Controllers
{
    using Microsoft.Extensions.HealthChecks;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// the health check controller
    /// </summary>
    public class HealthCheckController : ApiController
    {
        /// <summary>
        /// the health check service
        /// </summary>
        private IHealthCheckService healthCheckService;

        /// <summary>
        /// the constructor for the health check controller
        /// </summary>
        public HealthCheckController()
            : this(GlobalHealthChecks.Service)
        {
        }

        /// <summary>
        /// the constructor for the health check controller
        /// </summary>
        /// <param name="service"></param>
        public HealthCheckController(IHealthCheckService service)
        {
            this.healthCheckService = service;
        }

        /// <summary>
        /// runs a health check task
        /// </summary>
        /// <returns>an action result</returns>
        [Route("hc")]
        [HttpGet]
        public async Task<IHttpActionResult> HealthCheck()
        {
            var result = await healthCheckService.RunGroupAsync(healthCheckService.GetGroup("Basic"));

            return EnforceStatusPolicyResult(result);
        }

        /// <summary>
        /// the health check diagnostic
        /// </summary>
        /// <returns></returns>
        [Route("hcd")]
        [HttpGet]
        public async Task<IHttpActionResult> HealthCheckDiagnostics()
        {
            var result = await healthCheckService.CheckHealthAsync(default(CancellationToken));

            return EnforceStatusPolicyResult(result);
        }

        /// <summary>
        /// the status policy enforcer
        /// </summary>
        /// <param name="result">the health check result</param>
        /// <returns>a status policy</returns>
        private IHttpActionResult EnforceStatusPolicyResult(CompositeHealthCheckResult result)
        {
            HttpStatusCode statusCode = HttpStatusCode.ServiceUnavailable;

            if (result.CheckStatus == CheckStatus.Healthy)
            {
                statusCode = HttpStatusCode.OK;
            }

            return Content(statusCode, result);
        }
    }
}