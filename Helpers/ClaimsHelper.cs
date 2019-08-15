#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="ClaimsHelper.cs" company="United Shore Financial Services LLC.">
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
    using Castle.Core.Internal;
    using System.Linq;
    using System.Security.Claims;
    using USFS.Core.Command;
    using USFS.Domain.Me2U.Contracts.Queries;
    using USFS.Domain.Me2U.DTO;

    /// <summary>
    /// the Helper class handling all of the Claims functionality
    /// </summary>
    public class ClaimsHelper : IClaimsHelper
    {
        /// <summary>
        /// Instantiate the command bus
        /// </summary>
        private ICommandBus commandBus;

        /// <summary>
        /// Constant string for the Type of Name 
        /// </summary>
        private const string NameIdClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

        /// <summary>
        /// Intializing constructor to create new CommandBus
        /// </summary>
        /// <param name="commandBus"></param>
        public ClaimsHelper(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }

        /// <summary>
        /// returns the Username of the User from the Claims Identity 
        /// </summary>
        /// <param name="identity">the Identity from the ADFS Claim</param>
        /// <returns>a string of the user's name</returns>
        public string GetUserNameFromClaim(ClaimsIdentity identity)
        {

            if (identity.Claims.IsNullOrEmpty())
            {
                return null;
            }
            Claim userName = identity.Claims.FirstOrDefault(x =>
                x.Type.Contains(NameIdClaimType));

            return userName?.Value;

        }

        /// <summary>
        /// Returns a bool to determine if the user is an admin or not
        /// </summary>
        /// <param name="identity">the Identity from the Claim</param>
        /// <returns>true if the user is an Admin</returns>
        public bool IsUserAdmin(ClaimsIdentity identity)
        {
            if (identity.Claims.IsNullOrEmpty())
            {
                return false;
            }
            var userName = GetUserNameFromClaim(identity);
            var allAdmins = commandBus.ProcessQuery(new GetAllAdminsQuery());
            if (allAdmins.IsNullOrEmpty())
            {
                return false;
            }

            Admin admin = allAdmins.FirstOrDefault(a => a.IsActive && a.LoginId == userName);

            return admin != null;
        }
    }
}