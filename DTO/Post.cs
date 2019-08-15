#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="Post.cs" company="United Shore Financial Services LLC.">
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

using System;
using System.Collections.Generic;

namespace USFS.Domain.Me2U.DTO
{

    /// <summary>
    /// A Post DTO Object
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Stores the id of the enum that holds the different post types, (Giving away, looking for, etc...)
        /// </summary>
        public string PostPurpose { get; private set; }

        /// <summary>
        /// Person who created the post
        /// </summary>   
        public string PostedBy { get; private set; }

        /// <summary>
        /// Database ID of Post 
        /// </summary>
        public int PostId { get; private set; }
        /// <summary>
        /// Title of the Post
        /// </summary>

        public string PostTitle { get; private set; }

        /// <summary>
        /// Description of the Post
        /// </summary>

        public string PostDescription { get; private set; }

        /// <summary>
        /// Date the Post was created
        /// </summary>
        public DateTime DatePosted { get; private set; }

        /// <summary>
        /// Determines if the post is active
        /// </summary>
        public int PostStatus { get; private set; }

        /// <summary>
        /// Pick-up Location for item
        /// </summary>

        public string Location { get; set; }

        /// <summary>
        /// Date the post expires
        /// </summary>

        public DateTime ExpirationDate { get; private set; }    

        /// <summary>
        /// DataBase Id for the parent category that the Post belongs to
        /// </summary>

        public int CategoryId { get; private set; }

        /// <summary>
        /// Database ID for the Category of the Post
        /// </summary>

        public int SubCategoryId { get; private set; }

        /// <summary>
        ///The pictures attached to the post
        /// </summary>
        public List<string> Pictures { get; private set; }


        /// <summary>
        /// Person who created the post
        /// </summary>   
        public string PostedByFullName { get; private set; }

        /// <summary>
        /// Person who created the post
        /// </summary>   
        public string PostedByEmailAddress { get; private set; }

        /// <summary>
        /// File path for images.
        /// </summary>
        public List<Picture> TestPicturePaths { get; private set; }

        //Overloaded Constructors
        /// <summary>
        /// Constructor for Post class (1 parameter)
        /// </summary>
        /// <param name="postId">the id of the item post</param>
        public Post(int postId)
        {
            PostId = postId;
        }

        /// <summary>
        /// Constructor for Post class (10 parameters)
        /// </summary>
        /// <param name="postPurpose">Number that represents the purpose of a post (giving away / requesting)</param>
        /// <param name="postTitle">The title of the item post</param>
        /// <param name="postDescription">A description of the item being posted</param>
        /// <param name="postId">the id of the post</param>
        /// <param name="datePosted">the date the item was posted</param>
        /// <param name="subCategoryId">the id of the subcategory the item belongs to</param>
        /// <param name="categoryId">the id of the category the item belongs to</param>
        /// <param name="expirationDate">The date the post will switch to inactive (if in active status)</param>
        /// <param name="postedBy">the individual the item was posted by</param>
        /// <param name="postStatus">the status of the post (active, pending, delivered, etc.)</param>
        public Post(string postPurpose, string postTitle, string postDescription, int postId, DateTime datePosted, int subCategoryId, int categoryId, DateTime expirationDate, string postedBy, int postStatus) :
            this(postId)
        {
            PostPurpose = postPurpose;
            PostTitle = postTitle;
            PostDescription = postDescription;
            DatePosted = datePosted;
            SubCategoryId = subCategoryId;
            CategoryId = categoryId;
            ExpirationDate = expirationDate;
            PostedBy = postedBy;
            PostStatus = postStatus;
        }

        /// Constructor for Post class (9 parameters)
        /// </summary>
        /// <param name="postPurpose">Number that represents the purpose of a post (giving away / requesting)</param>
        /// <param name="postTitle">The title of the item post</param>
        /// <param name="postDescription">A description of the item being posted</param>
        /// <param name="datePosted">the date the item was posted</param>
        /// <param name="subCategoryId">the id of the subcategory the item belongs to</param>
        /// <param name="categoryId">the id of the category the item belongs to</param>
        /// <param name="expirationDate">The date the post will switch to inactive (if in active status)</param>
        /// <param name="postedBy">the individual the item was posted by</param>
        /// <param name="postStatus">the status of the post (active, pending, delivered, etc.)</param>
        public Post(string postPurpose, string postTitle, string postDescription, DateTime datePosted, int subCategoryId, int categoryId, DateTime expirationDate, string postedBy, int postStatus)
        {
            PostPurpose = postPurpose;
            PostTitle = postTitle;
            PostDescription = postDescription;
            DatePosted = datePosted;
            SubCategoryId = subCategoryId;
            CategoryId = categoryId;
            ExpirationDate = expirationDate;
            PostedBy = postedBy;
            PostStatus = postStatus;
        }

        /// <summary>
        /// Constructor for Post class (12 parameters)
        /// </summary>
        /// <param name="postPurpose">Number that represents the purpose of a post (giving away / requesting)</param>
        /// <param name="postTitle">The title of the item post</param>
        /// <param name="postDescription">A description of the item being posted</param>
        /// <param name="postId">the id of the post</param>
        /// <param name="datePosted">the date the item was posted</param>
        /// <param name="subCategoryId">the id of the subcategory the item belongs to</param>
        /// <param name="categoryId">the id of the category the item belongs to</param>
        /// <param name="expirationDate">The date the post will switch to inactive (if in active status)</param>
        /// <param name="postedBy">the individual the item was posted by</param>
        /// <param name="postStatus">the status of the post (active, pending, delivered, etc.)</param>
        /// <param name="postedByFullName">The full name of the individual who posted an item</param>
        /// <param name="postedByEmailAddress">The email address of the individual who posted an item</param>
        public Post(string postPurpose, string postTitle, string postDescription, int postId, DateTime datePosted, int subCategoryId, int categoryId, DateTime expirationDate, string postedBy, int postStatus, string postedByFullName, string postedByEmailAddress) :
            this(postPurpose, postTitle, postDescription, postId, datePosted, subCategoryId, categoryId, expirationDate, postedBy,postStatus)
        {
            PostedByFullName = postedByFullName;
            PostedByEmailAddress = postedByEmailAddress;
        }

        /// <summary>
        /// Constructor for Post class (0 parameters)
        /// </summary>
        public Post()
        { }

        /// <summary>
        /// Sets the pictures field to a list of pictures
        /// </summary>
        /// <param name="pictureList">a list of pictures</param>
        public void SetPostPictures(List<string> pictureList)
        {
            Pictures = pictureList;
        }

        /// <summary>
        /// Sets the testpicturepath
        /// </summary>
        /// <param name="pictureList">a list of pictures</param>
        public void SetTestPicturePaths(List<Picture> pictureList)
        {
            TestPicturePaths = pictureList;
        }
    }
}
