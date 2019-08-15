#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="UtilitiesModel.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.WebUI.Me2U.Models
{
    /// <summary>
    /// Utilities model class
    /// </summary>
    public class UtilitiesModel : BaseViewModel
    {
        /// <summary>
        /// Check if the user is signed ing
        /// </summary>
        public bool IsAuthenticated { get; set; }

        /// <summary>
        /// the users login name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// check if user is admin
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}