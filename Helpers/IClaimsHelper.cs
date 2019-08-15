#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="IClaimsHelper.cs" company="United Shore Financial Services LLC.">
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

    using System.Security.Claims;

    /// <summary>
    /// the claims helper interface
    /// </summary>
    public interface IClaimsHelper
    {
        /// <summary>
        /// returns the Username of the User from the Claims Identity 
        /// </summary>
        /// <param name="identity">the Identity from the ADFS Claim</param>
        /// <returns>a string of the user's name</returns>
        string GetUserNameFromClaim(ClaimsIdentity identity);

        /// <summary>
        /// Returns a bool to determine if the user is an admin or not
        /// </summary>
        /// <param name="identity">the Identity from the Claim</param>
        /// <returns>true if the user is an Admin</returns>
        bool IsUserAdmin(ClaimsIdentity identity);
    }
}