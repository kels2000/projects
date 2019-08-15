#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="United Shore Financial Services LLC.">
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
    using System.Security.Claims;
    using System.Web.Mvc;
    using USFS.Core.Command;
    using USFS.Domain.Me2U.Contracts.Commands;
    using USFS.Domain.Me2U.Contracts.Queries;
    using USFS.WebUI.Me2U.Helpers;
    using USFS.WebUI.Me2U.Models;

    /// <summary>
    /// the home controller
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// the command bus
        /// </summary>
        private readonly ICommandBus commandBus;

        /// <summary>
        /// the claims helper
        /// </summary>
        private readonly IClaimsHelper claimsHelper;

        /// <summary>
        /// the logging helper
        /// </summary>
        private readonly ILoggingHelper loggingHelper;

        /// <summary>
        /// the constructor for the home controller
        /// </summary>
        /// <param name="commandBus">the command bus</param>
        /// <param name="claimsHelper">the claims helper</param>
        /// <param name="loggingHelper">the logging helper</param>
        public HomeController(ICommandBus commandBus, IClaimsHelper claimsHelper, ILoggingHelper loggingHelper)
        {
            this.commandBus = commandBus;
            this.loggingHelper = loggingHelper;
            this.claimsHelper = claimsHelper;
        }

        /// <summary>
        /// Index method for home page. 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            CheckAllPostsForExpirationDateCommand command = new CheckAllPostsForExpirationDateCommand();
            commandBus.Execute(command);

            return View("Index", model);
        }

        /// <summary>
        /// searches posts for given text
        /// </summary>
        /// <param name="searchText">the search text</param>
        /// <returns>the index view with a filtered models</returns>
        [HttpPost]
        public ActionResult Search(string searchText)
        {
            PostModel model = new PostModel();
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            GetAllPostsBySearchQuery searchQuery = new GetAllPostsBySearchQuery(searchText);
            model.SearchResults = commandBus.ProcessQuery(searchQuery);
            model.SearchText = searchText;

            return View("/Views/Post/Index.cshtml", model);
        }
    }
}