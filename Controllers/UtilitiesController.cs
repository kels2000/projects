#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="UtilitiesController.cs" company="United Shore Financial Services LLC.">
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
    using USFS.WebUI.Me2U.Constants;
    using USFS.WebUI.Me2U.Helpers;
    using USFS.WebUI.Me2U.Models;

    /// <summary>
    /// Responsible for handling all utility related controller actions
    /// </summary>
    [Authorize]
    public class UtilitiesController : Controller
    {
        /// <summary>
        /// Claims helper
        /// </summary>
        private IClaimsHelper claimsHelper;

        /// <summary>
        /// Initializing constructor that creates a new IClaimsHelper
        /// </summary>
        /// <param name="claimsHelper"></param>
        public UtilitiesController(IClaimsHelper claimsHelper)
        {
            this.claimsHelper = claimsHelper;
        }

        /// <summary>
        /// Populates utilities dropdown view
        /// </summary>
        /// <returns>Utilities dropdown menu according to user's admin permissions</returns>
        public ActionResult Index()
        {
            UtilitiesModel model = new UtilitiesModel();
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;

            model.IsAuthenticated = Request.IsAuthenticated;
            model.UserName = claimsHelper.GetUserNameFromClaim(identity);
            model.IsAdmin = claimsHelper.IsUserAdmin(identity);
            return PartialView(ViewNames.UtilitiesDropdown, model);
        }
    }
}