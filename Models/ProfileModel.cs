#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="ProfileModel.cs" company="United Shore Financial Services LLC.">
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

    /// <summary>
    /// Profile view model
    /// </summary>
    public class ProfileModel : BaseViewModel
    {
        /// <summary>
        /// All of the posts under the current logged in user
        /// </summary>
        public List<Post> Posts { get; set; }

        /// <summary>
        /// Specific post of the logged in user
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// All of the claims for the logged in user
        /// </summary>
        public List<PostClaim> PostClaims { get; set; }
    }
}