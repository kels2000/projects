#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="PostModel.cs" company="United Shore Financial Services LLC.">
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
    /// The specific post view model
    /// </summary>
    public class PostModel : BaseViewModel
    {
        /// <summary>
        /// Gets all of the post previews for each category
        /// </summary>
        public IEnumerable<PostPreview> AllPostsForCategory { get; set; }

        /// <summary>
        /// Returns the search results
        /// </summary>
        public IEnumerable<PostPreview> SearchResults { get; set; }

        /// <summary>
        /// Holds the information for a specific post
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// Contains all of the post previews
        /// </summary>
        public IEnumerable<PostPreview> PostPreviews { get; set; }

        /// <summary>
        /// The search text used
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// The category title used
        /// </summary>
        public string CategoryTitle { get; set; }
    }
}