﻿#region Copyright
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
    using System.Web.Mvc;
    using USFS.WebUI.Me2U.Constants;

    /// <summary>
    /// The Account Login controller.
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        /// <summary>
        /// If not properly authenticated or given access, return to this page
        /// </summary>
        /// <returns></returns>
        public ActionResult RedirectToErrorPage()
        {
            return View(ViewNames.FailedToAuthenticate);
        }
    }
}