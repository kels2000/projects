using System;
using System.Collections.Generic;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    /// <summary>
    /// Interface for the post repository
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// Method that gets post for a category
        /// </summary>
        /// <param name="category">the category to get posts for</param>
        /// <returns>a collection of post previews for items in the category</returns>
        IEnumerable<PostPreview> GetAllPostsForCategoryFixed(Category category);

        /// <summary>
        /// Method that gets all posts for a sub-category
        /// </summary>
        /// <param name="category">the information about the category to get posts for</param>
        /// <returns>a collection of post previews for the sub-category</returns>
        IEnumerable<PostPreview> GetAllPostsForSubCategory(Category category);

        /// <summary>
        /// Method that gets all post for a search string
        /// </summary>
        /// <param name="search">the string the user input to search for</param>
        /// <returns>a collection of post previews that match the search criteria</returns>
        IEnumerable<PostPreview> LoadAllPostsForSearchStringFixed(string search);

        /// <summary>
        /// Method that gets all the recent post for the carousel
        /// </summary>
        /// <returns>a collection of post previews to display in the carousel</returns>
        IEnumerable<PostPreview> GetRecentPostsForCarousel();

        /// <summary>
        /// Method that gets a post by the post id number
        /// </summary>
        /// <param name="post">an object containing the id of the post to retrieve</param>
        /// <returns>the information about a post matching the id</returns>
        Post GetPostByPostId(int postId);

        /// <summary>
        /// Method that Inserts a post into the database
        /// </summary>
        /// <param name="post">the information about the post to be inserted</param>
        /// <returns>the post that was inserted</returns>
        Post InsertPost(Post post);

        /// <summary>
        /// Method that inserts an image into the database
        /// </summary>
        /// <param name="picture">the image to be inserted</param>
        /// <returns>the image that was inserted</returns>
        Picture InsertPicture(Picture picture);

        /// <summary>
        /// Method that gets the most recent post from an individual
        /// </summary>
        /// <param name="username">the username of the individual to retrieve the post for</param>
        /// <returns>the information about the most recent post</returns>
        Post GetLatestPostByUser(string username);

        /// <summary>
        /// Method that selects the images associated to a post
        /// </summary>
        /// <param name="post">the information about the post to get the images for</param>
        /// <returns>a collection of all the images associated with a post</returns>
        List<Picture> SelectPicturesForPost(int postId);

        /// <summary>
        /// Method that updates a post
        /// </summary>
        /// <param name="post">the post to be updated</param>
        /// <returns>the post that was updated</returns>
        Post UpdatePost(Post post);

        /// <summary>
        /// Method that selects all posts by a user
        /// </summary>
        /// <param name="loginName">the login of the individual to get posts for</param>
        /// <returns>a collection of posts for a user</returns>
        List<Post> SelectAllPostsByUser(string loginName);

        /// <summary>
        /// Method that deletes an image from a post
        /// </summary>
        /// <param name="picture">the image to be removed</param>
        /// <returns>a collection of the remaining images on a post</returns>
        List<Picture> RemovePicture(Picture picture);

        /// <summary>
        /// Method that inserts a claim on a post
        /// </summary>
        /// <param name="postClaim">the information about the claim to be inserted</param>
        /// <returns>the claim that was inserted</returns>
        PostClaim InsertPostClaim(PostClaim postClaim);

        /// <summary>
        /// Method that selects all post claims for an individual
        /// </summary>
        /// <param name="loginName">the login of the individual to retrieve posts for</param>
        /// <returns>a collection of all claims from an individual</returns>
        List<PostClaim> SelectAllPostClaimsByUser(string loginName);

        /// <summary>
        /// Method that selects all of the post claims from and individual in the past 30 days
        /// </summary>
        /// <param name="loginName">the login name of the individual</param>
        /// <returns>a collection of all posts in the last 30 days for an individual</returns>
        List<PostClaim> SelectAllPostClaimsByUserWithinThirtyDays(string loginName);

        /// <summary>
        /// Method that checks the expiration date on all active posts.
        /// </summary>
        void CheckAllPostsForExpirationDate();

        /// <summary>
        /// Method that updates a post to delivered
        /// </summary>
        /// <param name="post">the post object of the post to be updated</param>
        /// <param name="userName">the username of the individual who marked the post as delivered</param>
        void UpdatePostToDelivered(Post post, string userName);

        /// <summary>
        /// Method that removes a post
        /// </summary>
        /// <param name="post">the post to be removed</param>
        /// <param name="userName">the username of the individual who deleted the post</param>
        void RemovePost(Post post, string userName);

        /// <summary>
        /// Updates a post to active and sets a new expiration date
        /// </summary>
        /// <param name="postId">the post id to re-post</param>
        /// <param name="expirationDate">the date the post will become inactive</param>
        /// <param name="userName">the username of the individual who is posting the item</param>
        void UpdatePostToActiveAndUpdateExpirationDate(int postId, DateTime expirationDate, string userName);

        /// <summary>
        /// Gets all of the 'looking for' posts for a category
        /// </summary>
        /// <param name="category">the category to find posts for</param>
        /// <returns>a collection of previews for all items in a categeory.</returns>
        IEnumerable<PostPreview> GetAllItemRequestPostsForCategory(Category category);

        /// <summary>
        /// Gets all of the item request posts
        /// </summary>
        /// <returns>a collection of post previews representing all of the item request posts</returns>
        IEnumerable<PostPreview> GetAllItemRequestPosts();
    }
}
