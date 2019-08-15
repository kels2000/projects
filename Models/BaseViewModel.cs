#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="BaseViewModel.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.WebUI.Me2U.Models
{
    using System.Collections.Generic;
    using USFS.Domain.Me2U.DTO;
    using USFS.Lending;

    /// <summary>
    /// Base abstract view model for all other views to inherit from. 
    /// </summary>
    public abstract class BaseViewModel
    {
        /// <summary>
        /// Object containing information on current user. 
        /// </summary>
        public User CurrentUser { get; set; }

        /// <summary>
        /// the users login name
        /// </summary>
        public string UserLoginName { get; set; }

        /// <summary>
        /// a list of categories
        /// </summary>
        public IEnumerable<Category> Categories { get; set; }
    }
}