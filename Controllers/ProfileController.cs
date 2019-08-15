#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="ProfileController.cs" company="United Shore Financial Services LLC.">
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
    using USFS.Domain.Me2U.Contracts.Queries;
    using USFS.WebUI.Me2U.Constants;
    using USFS.WebUI.Me2U.Helpers;
    using USFS.WebUI.Me2U.Models;

    /// <summary>
    /// Responsible for handing profile controller actions
    /// </summary>
    [Authorize]
    public class ProfileController : Controller
    {
        /// <summary>
        /// The USFS command bus
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
        /// constructor for the Profile controller
        /// </summary>
        /// <param name="commandBus">the command bus</param>
        /// <param name="claimsHelper">the claims helper</param>
        /// <param name="loggingHelper">the logging helper</param>
        public ProfileController(ICommandBus commandBus, IClaimsHelper claimsHelper, ILoggingHelper loggingHelper)
        {
            this.commandBus = commandBus;
            this.claimsHelper = claimsHelper;
            this.loggingHelper = loggingHelper;
        }

        /// <summary>
        /// Populates for profile model to display profile home page
        /// </summary>
        /// <returns>Profile homepage with model data</returns>
        public ActionResult Index()
        {
            string userName = GetUserNameFromClaimIdentity();
            ProfileModel model = new ProfileModel()
            {
                Posts = commandBus.ProcessQuery(new SelectAllPostsByUserQuery(userName)),
                PostClaims = commandBus.ProcessQuery(new SelectAllPostClaimsByUserQuery(userName))
            };
            model.UserLoginName = claimsHelper.GetUserNameFromClaim((ClaimsIdentity)User.Identity);

            return View("Index", model);
        }

        /// <summary>
        /// Reloads the portion of the profile page that contains a users posts.
        /// </summary>
        /// <returns>the partial view and an updated model for the user's posts.</returns>
        public ActionResult ReloadPostsTable()
        {
            string userName = GetUserNameFromClaimIdentity();
            ProfileModel model = new ProfileModel()
            {
                Posts = commandBus.ProcessQuery(new SelectAllPostsByUserQuery(userName)),
                PostClaims = commandBus.ProcessQuery(new SelectAllPostClaimsByUserQuery(userName))
            };

            return PartialView(ViewNames.MyPostsTable, model);
        }

        /// <summary>
        /// returns the user login ID from the claims ticket
        /// </summary>
        /// <returns>the users login ID</returns>
        private string GetUserNameFromClaimIdentity()
        {
            ClaimsIdentity id = (ClaimsIdentity)User.Identity;
            return claimsHelper.GetUserNameFromClaim(id);
        }
    }
}