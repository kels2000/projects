#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="PostPreview.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.Domain.Me2U.DTO
{
    /// <summary>
    /// Class for a post preview. Used to build the search results/ category view for postings.
    /// </summary>
    public class PostPreview
    {
        /// <summary>
        /// The id for the post type.
        /// </summary>
        public string PostPurpose { get; private set; }

        /// <summary>
        /// Database ID of Post 
        /// </summary>
        public int PostId { get; private set; }

        /// <summary>
        /// Title of the Post
        /// </summary>
        public string PostName{ get; private set; }

        /// <summary>
        /// One photo from the database attached to this post id
        /// </summary>
        public string PictureImagePath { get; private set; }

        /// <summary>
        /// The status of the post. (From PostStatusEnum)
        /// </summary>
        public int PostStatus { get; private set; }

        /// <summary>
        /// The type of the post. (ticket or team member)
        /// </summary>
        public string PostType { get; private set; }

        public int CategoryId { get; set; }

        /// <summary>
        /// Constructor for post preview.
        /// </summary>
        /// <param name="postPurpose">The id of the purpose of the post (requesting / giving away)</param>
        /// <param name="postId">The id of the post.</param>
        /// <param name="postName">The name of the post. (Given by user)</param>
        /// <param name="pictureImagePath">The path to the image associated with the post.</param>
        /// <param name="postType">The type of the post. (team member/ ticket)</param>
        /// <param name="postStatus">The status of the post. (From PostStatusEnum)</param>
        public PostPreview(string postPurpose, int postId, string postName, string pictureImagePath, string postType, int postStatus)
        {
            PostPurpose = postPurpose;
            PostId = postId;
            PostName = postName;
            PictureImagePath = pictureImagePath;
            PostType = postType;
            PostStatus = postStatus;
        }

        /// <summary>
        /// No arg constructor.
        /// </summary>
        public PostPreview()
        {
            
        }

    }
}