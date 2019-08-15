#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="CreatePostModel.cs" company="United Shore Financial Services LLC.">
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
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using USFS.Domain.Me2U.DTO;

    /// <summary>
    /// Model to hold information about creating a post.
    /// </summary>
    public class CreatePostModel : BaseViewModel
    {
        /// <summary>
        /// Stores the id of the enum that holds the different post types, (Giving away, looking for, etc...)
        /// </summary>
        public string PostPurpose { get; set; }

        /// <summary>
        /// Person who created the post
        /// </summary>   
        public string PostedBy { get; set; }

        /// <summary>
        /// Database ID of Post 
        /// </summary>
        public int PostId { get; set; }
        /// <summary>
        /// Title of the Post
        /// </summary>

        public string PostTitle { get; set; }

        /// <summary>
        /// Description of the Post
        /// </summary>

        public string PostDescription { get; set; }

        /// <summary>
        /// Pick-up Location for item
        /// </summary>

        public string Location { get; set; }

        /// <summary>
        /// Date the Post was created
        /// </summary>
        public DateTime DatePosted { get; set; }

        /// <summary>
        /// Determines if the post is active
        /// </summary>
        public int PostStatus { get; set; }

        /// <summary>
        /// Date the post expires
        /// </summary>

        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// DataBase Id for the parent category that the Post belongs to
        /// </summary>

        public int CategoryId { get; set; }

        /// <summary>
        /// Database ID for the Category of the Post
        /// </summary>

        public int SubCategoryId { get; set; }

        /// <summary>
        ///The pictures attached to the post
        /// </summary>
        public List<string> Pictures { get; set; }

        /// <summary>
        /// Person who created the post
        /// </summary>   
        public string PostedByFullName { get; set; }

        /// <summary>
        /// Person who created the post
        /// </summary>   
        public string PostedByEmailAddress { get; set; }

        /// <summary>
        /// File path for images.
        /// </summary>
        public List<Picture> TestPicturePaths { get; set; }

        /// <summary>
        /// a select list that contains the subcategory items.
        /// </summary>
        public IEnumerable<SelectListItem> SubcategoryList { get; set; }
    }
}