#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="CheckAdminRightsQuery.cs" company="United Shore Financial Services LLC.">
//     Copyright &copy; United Shore Financial Services Inc. 2017.
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
using USFS.Core.Command;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// CheckAdminRights Query Class
    /// </summary>
    public class CheckAdminRightsQuery : IQuery<bool>
    {
        /// <summary>
        /// User login name to be passed to db for admin rights check
        /// </summary>
        public string LoginName { get; private set; }

        /// <summary>
        /// Check admin rights query constructor 
        /// </summary>
        /// <param name="loginName"></param>
        public CheckAdminRightsQuery(string loginName)
        {
            LoginName = loginName;
        }
    }
}