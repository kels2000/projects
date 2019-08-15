#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="PostRepository.cs" company="United Shore Financial Services LLC.">
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
using System.Linq;
using USFS.Core.Data;
using USFS.Domain.Me2U.Constants;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    /// <summary>
    /// Class that handles interaction with the database for posts
    /// </summary>
    public class PostRepository : IPostRepository
    {

        /// <summary>
        /// Data repository from USFS.Core
        /// </summary>
        private DataRepository db { get; set; }


        /// <summary>
        /// Constructor method for UserRepository
        /// </summary>
        /// <param name="database"></param>
        public PostRepository(DataRepository database)
        {
            db = database;
        }

        /// <summary>
        /// Gets all of the item posts for a category
        /// </summary>
        /// <param name="category">the category to retrieve items for</param>
        /// <returns>a collection of posts</returns>
        public IEnumerable<PostPreview> GetAllPostsForCategoryFixed(Category category)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllItemPostForCategory);
            statement.AddParameter("CategoryId", category.CategoryId);
            return db.ExecuteStoredProc(statement, PostPreviewMapper);
        }

        /// <summary>
        /// Selects all of the posts by a users login name
        /// </summary>
        /// <param name="loginName">the login name of the user whose posts we are looking for</param>
        /// <returns>a list of all posts by the individual</returns>
        public List<Post> SelectAllPostsByUser(string loginName)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.SelectAllPostsByUser);
            statement.AddParameter("UserName", loginName);
            return db.ExecuteStoredProc(statement, PostMapper).ToList();
        }

        /// <summary>
        /// Gets all of the post for a subcategory
        /// </summary>
        /// <param name="category">the information about the item category</param>
        /// <returns>a collection of post previews for that subcategory</returns>
        public IEnumerable<PostPreview> GetAllPostsForSubCategory(Category category)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllItemPostsForSubCategory);
            statement.AddParameter("CategoryId", category.CategoryId);
            statement.AddParameter("SubCategoryId", category.SubCategoryId);
            return db.ExecuteStoredProc(statement, PostPreviewMapper);
        }

        /// <summary>
        /// Gets all of the posts that match search critera.
        /// </summary>
        /// <param name="search">the search parameter</param>
        /// <returns>a collection of post previews that match the search parameter</returns>
        public IEnumerable<PostPreview> LoadAllPostsForSearchStringFixed(string search)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllPostsBySearch);
            statement.AddParameter("searchText", search);
            return db.ExecuteStoredProc(statement, PostPreviewMapper);
        }

        /// <summary>
        /// Gets posts to display in the carousel.
        /// </summary>
        /// <returns>a collection of post previews to show on the top of the category page.</returns>
        public IEnumerable<PostPreview> GetRecentPostsForCarousel()
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetRecentPostsForCarousel);
            return db.ExecuteStoredProc(statement, PostPreviewMapper);
        }

        /// <summary>
        /// Gets all of the 'looking for' posts for a category
        /// </summary>
        /// <param name="category">the category to find posts for</param>
        /// <returns>a collection of previews for all items in a categeory.</returns>
        public IEnumerable<PostPreview> GetAllItemRequestPostsForCategory(Category category)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllItemRequestPostsForCategory);
            statement.AddParameter("CategoryId", category.CategoryId);
            return db.ExecuteStoredProc(statement, PostPreviewMapper);
        }

        /// <summary>
        /// Gets a post by the post id
        /// </summary>
        /// <param name="post">information about the post</param>
        /// <returns>a single post that matches the post id.</returns>
        public Post GetPostByPostId(int postId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetPostByPostId);
            statement.AddParameter("PostId", postId);
            return db.ExecuteStoredProc(statement, PostMapperWithFullName).FirstOrDefault();
        }

        /// <summary>
        /// Gets the images for a post.
        /// </summary>
        /// <param name="post">information about the post</param>
        /// <returns>a list of images associated with a post.</returns>
        public List<Picture> SelectPicturesForPost(int postId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.SelectPicturesForPost);
            statement.AddParameter("PostId", postId);
            return db.ExecuteStoredProc(statement, PictureMapper).ToList();
        }

        /// <summary>
        /// Inserts a post into the database
        /// </summary>
        /// <param name="post">the post data</param>
        /// <returns>returns the post that was inserted</returns>
        public Post InsertPost(Post post)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.InsertPost);
            statement.AddParameter("PurposeTypeId", Convert.ToInt32(post.PostPurpose));
            statement.AddParameter("PostTitle", post.PostTitle);
            statement.AddParameter("PostDescription", post.PostDescription);
            statement.AddParameter("DatePosted", post.DatePosted);
            statement.AddParameter("CategoryID", post.CategoryId);
            statement.AddParameter("SubCategoryId", post.SubCategoryId);
            statement.AddParameter("ExpirationDate", post.ExpirationDate);
            statement.AddParameter("PostStatus", post.PostStatus);
            statement.AddParameter("PostedBy", post.PostedBy);
            return db.ExecuteStoredProc(statement, PostMapper).FirstOrDefault();
        }

        /// <summary>
        /// Inserts an image that is associated to a post
        /// </summary>
        /// <param name="picture">the image to be inserted</param>
        /// <returns>the image that was inserted</returns>
        public Picture InsertPicture(Picture picture)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.InsertPicture);
            statement.AddParameter("PostId", picture.PostId);
            statement.AddParameter("EventId", picture.EventId);
            statement.AddParameter("PictureImagePath", picture.PictureImagePath);
            return db.ExecuteStoredProc(statement, PictureMapper).FirstOrDefault();
        }

        /// <summary>
        /// Inserts a claim for a post.
        /// </summary>
        /// <param name="postClaim">information about the post claim.</param>
        /// <returns>the claim that was inserted.</returns>
        public PostClaim InsertPostClaim(PostClaim postClaim)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.InsertPostClaim);
            statement.AddParameter("ClaimedPostId", postClaim.ClaimedPostId);
            statement.AddParameter("ClaimerName", postClaim.ClaimerName);
            statement.AddParameter("EmailAddress", postClaim.EmailAddress);
            statement.AddParameter("DateClaimed", postClaim.DateClaimed);
            return db.ExecuteStoredProc(statement, PostClaimMapper).FirstOrDefault();
        }

        /// <summary>
        /// Gets all post claims for an indiviudal
        /// </summary>
        /// <param name="loginName">the login of the individual to get the claims for</param>
        /// <returns>a list of all claims by an individual</returns>
        public List<PostClaim> SelectAllPostClaimsByUser(string loginName)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.SelectAllPostClaimsByUser);
            statement.AddParameter("UserName", loginName);
            return db.ExecuteStoredProc(statement, PostClaimMapper).ToList();
        }

        /// <summary>
        /// Gets all post claims for an individual within 30 days.
        /// </summary>
        /// <param name="loginName">the login of the individual to get the claims for</param>
        /// <returns>a list of all claims for an individual within 30 days</returns>
        public List<PostClaim> SelectAllPostClaimsByUserWithinThirtyDays(string loginName)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.SelectAllPostClaimsByUserWithinThirtyDays);
            statement.AddParameter("UserName", loginName);
            return db.ExecuteStoredProc(statement, PostClaimMapper).ToList();
        }

        /// <summary>
        /// Get the latest post by a user
        /// </summary>
        /// <param name="username">the login of the individual to use to look for a post</param>
        /// <returns>the latest post of an individual</returns>
        public Post GetLatestPostByUser(string username)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetLatestPostByUser);
            statement.AddParameter("Username", username);
            return db.ExecuteStoredProc(statement, PostMapperWithFullName).FirstOrDefault();
        }

        /// <summary>
        /// Gets all of the item request posts
        /// </summary>
        /// <returns>a collection of post previews representing all of the item request posts</returns>
        public IEnumerable<PostPreview> GetAllItemRequestPosts()
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetAllItemRequestPosts);
            return db.ExecuteStoredProc(statement, PostPreviewMapper);
        }

        /// <summary>
        /// Removes a post.
        /// </summary>
        /// <param name="post">the post to be removed.</param>
        /// <param name="userName">the username of the individual who is posting the item</param>
        public void RemovePost(Post post, string userName)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.UpDatePostToDeleted);
            statement.AddParameter("PostId", post.PostId);
            statement.AddParameter("ModifiedBy", userName);
            db.ExecuteStoredProc(statement);
        }

        /// <summary>
        /// Updates a previously existing post.
        /// </summary>
        /// <param name="post">the post to be modified</param>
        /// <returns>the modified post.</returns>
        public Post UpdatePost(Post post)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.UpdatePost);
            statement.AddParameter("PostId", post.PostId);
            statement.AddParameter("PostTitle", post.PostTitle);
            statement.AddParameter("PostDescription", post.PostDescription);
            statement.AddParameter("DatePosted", post.DatePosted);
            statement.AddParameter("PostStatus", post.PostStatus);
            statement.AddParameter("ExpirationDate", post.ExpirationDate);
            statement.AddParameter("CategoryID", post.CategoryId);
            statement.AddParameter("SubCategoryId", post.SubCategoryId);
            statement.AddParameter("PostedBy", post.PostedBy);
            statement.AddParameter("PurposeTypeId", post.PostPurpose);
            return db.ExecuteStoredProc(statement, PostMapper).FirstOrDefault();
        }

        /// <summary>
        /// Changes the status of a post to delivered.
        /// </summary>
        /// <param name="post">the post to be updated</param>
        /// <param name="userName">the username of the individual who marked the item as delivered</param>
        public void UpdatePostToDelivered(Post post, string userName)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.UpdatePostToDelivered);
            statement.AddParameter("PostId", post.PostId);
            statement.AddParameter("ModifiedBy", userName);
            db.ExecuteStoredProc(statement);
        }

        /// <summary>
        /// Updates the status of a post to active and sets a new expiration date.
        /// </summary> 
        /// <param name="expirationDate">The date the post will become expired if it is not claimed</param>
        /// <param name="postId">the id of the post to change status to active.</param>
        /// <param name="userName">the username of the invidual who is repsting the item.</param>
        public void UpdatePostToActiveAndUpdateExpirationDate(int postId, DateTime expirationDate, string userName)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.UpDatePostToActiveAndUpdateExpiration);
            statement.AddParameter("PostId", postId);
            statement.AddParameter("ExpirationDate", expirationDate);
            statement.AddParameter("ModifiedBy", userName);
            db.ExecuteStoredProc(statement);
        }

        /// <summary>
        /// Remove an image from a post
        /// </summary>
        /// <param name="picture">information about the image to be removed</param>
        /// <returns>a list of all the removed images.</returns>
        public List<Picture> RemovePicture(Picture picture)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.RemovePhoto);
            statement.AddParameter("PostId", picture.PostId);
            statement.AddParameter("PictureImagePath", picture.PictureImagePath);
            statement.AddParameter("EventId", picture.EventId);
            return db.ExecuteStoredProc(statement, PictureMapper).ToList();
            
        }

        /// <summary>
        /// Checks the date the post becomes inactive.
        /// </summary>
        public void CheckAllPostsForExpirationDate()
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.CheckAllPostsForExpirationDate);
            db.ExecuteStoredProc(statement);
        }

        /// <summary>
        /// Maps an image to an object
        /// </summary>
        /// <param name="data">the record from the database</param>
        /// <param name="rownum">the row number of the record</param>
        /// <returns>the data from the database mapped to an object.</returns>
        private Picture PictureMapper(SqlReaderWrapper data, int rownum)
        {
           return new Picture(data.GetInt("PostId"), 
                               data.GetString("PictureImagePath"),
                               data.GetInt("EventId"));
            
        }

        /// <summary>
        /// Maps a post to an object
        /// </summary>
        /// <param name="data">the record from the database</param>
        /// <param name="rownum">the row number of the data</param>
        /// <returns>the data fro mthe database mapped to an object</returns>
        private Post PostMapper(SqlReaderWrapper data, int rownum)
        {
            return new Post(data.GetInt("PurposeTypeId").ToString(), data.GetString("PostTitle"), data.GetString("PostDescription"), data.GetInt("PostID"),
                data.GetDate("DatePosted"), (data.GetInt("SubCategoryId")),
                (data.GetInt("CategoryId")), data.GetDate("DatePosted"), data.GetString("PostedBy"),
                data.GetInt("PostStatus"));
        }

        /// <summary>
        /// Maps a claim to an object
        /// </summary>
        /// <param name="data">the record from the database</param>
        /// <param name="rownum">the row number of the record</param>
        /// <returns>the database information mapped to an object</returns>
        private PostClaim PostClaimMapper(SqlReaderWrapper data, int rownum)
        {
            return new PostClaim(data.GetInt("ClaimedPostId"), data.GetString("ClaimerName"),
                data.GetString("EmailAddress"),
                data.GetDate("DateClaimed"))
            {
                PostTitle = data.GetString("PostTitle")
            };
        }

        /// <summary>
        /// Maps the data from the database to an object
        /// </summary>
        /// <param name="data">the record from the database</param>
        /// <param name="rownum">the row number of the record</param>
        /// <returns>the information from the database mapped to an object</returns>
        private Post PostMapperWithFullName(SqlReaderWrapper data, int rownum)
        {
            return new Post(data.GetInt("PurposeTypeId").ToString(), data.GetString("PostTitle"), data.GetString("PostDescription"), data.GetInt("PostID"),
                data.GetDate("DatePosted"), data.GetInt("SubCategoryId"),
                data.GetInt("CategoryId"), data.GetDate("ExpirationDate"), data.GetString("PostedBy"),
                data.GetInt("PostStatus"), data.GetString("PostedByFullName"), data.GetString("PostedByEmailAddress"));
        }

        /// <summary>
        /// Maps the information from the database to an object
        /// </summary>
        /// <param name="data">the record from the database</param>
        /// <param name="rownum">the row number of the record</param>
        /// <returns>the data from the database mapped to an objecct</returns>
        private PostPreview PostPreviewMapper(SqlReaderWrapper data, int rownum)
        {
            return new PostPreview(
                data.GetInt("PurposeTypeId").ToString(),
                data.GetInt("PostID"),
                data.GetString("PostName"),
                data.GetString("PictureImagePath"),
                data.GetString("PostType"),
                data.GetInt("PostStatus")
                );
        }
    }
}
