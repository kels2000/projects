#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="StoredProcedures.cs" company="United Shore Financial Services LLC.">
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

namespace USFS.Domain.Me2U.Constants
{
    /// <summary>
    /// Class that holds the names of stored procedures as constants.
    /// </summary>
    public class StoredProcedures
    {
        //Category Stored Procedure Area----------------------------------------------------------------------     
        /// <summary>
        /// Stored procedure to select the subcategories for a parent category.
        /// </summary>
        public const string GetSubCategoriesByParentCategoryId = "[Me2You].[GetSubCategories]";

        //Post Stored Procedure Area--------------------------------------------------------------------------

        /// <summary>
        /// Stored procedure to get all sub categories when a link is clicked.
        /// </summary>
        public const string GetAllItemPostsForSubCategory = "[Me2You].[GetAllItemPostsForSubCategory]";

        /// <summary>
        /// Stored procedure to select all posts for a word typed into the search bar.
        /// </summary>
        public const string GetAllPostsBySearch = "[Me2You].[SearchForPosts]";

        /// <summary>
        /// Stored procedure to select The posts in a selected category.
        /// </summary>
        public const string GetAllItemPostForCategory = "[Me2You].[GetAllItemPostsForCategory]";

        /// <summary>
        /// Stored procedure to select the most recent posts for the front page carousel.
        /// </summary>
        public const string GetRecentPostsForCarousel = "[Me2You].[GetAllPostsForCarousel]";

        /// <summary>
        /// Stored procedure to select a post from the post id.
        /// </summary>
        public const string GetPostByPostId = "[Me2You].[GetPostByPostId]";

        /// <summary>
        /// Stored procedure to insert a post.
        /// </summary>
        public const string InsertPost = "[Me2You].[InsertPost]";

        /// <summary>
        /// Stored procedure to update a post.
        /// </summary>
        public const string UpdatePost = "[Me2You].[UpdatePost]";

        /// <summary>
        /// Stored procedure to select the Latest post by a user.
        /// </summary>
        public const string GetLatestPostByUser = "[Me2You].[GetLastPostByUser]";

        /// <summary>
        /// Stored Procedure to select all posts by a user.
        /// </summary>
        public const string SelectAllPostsByUser = "[Me2You].[SelectAllPostsByUser]";

        /// <summary>
        /// Stored Procedure to select all posts by a user.
        /// </summary>
        public const string InsertPostClaim = "[Me2You].[InsertPostClaim]";

        /// <summary>
        /// Stored Procedure to select all posts by a user.
        /// </summary>
        public const string SelectAllPostClaimsByUser = "[Me2You].[SelectAllPostClaimsByUser]";

        /// <summary>
        /// Stored Procedure to delete a post.
        /// </summary>
        public const string RemovePost = "[Me2You].[RemovePost]";

        /// <summary>
        /// Stored Procedure to select all posts by a user.
        /// </summary>
        public const string SelectAllPostClaimsByUserWithinThirtyDays = "[Me2You].[SelectAllPostClaimsByUserWithinLastThirtyDays]";

        /// <summary>
        /// Stored Procedure to make all posts past expiration date inactive.
        /// </summary>
        public const string CheckAllPostsForExpirationDate = "[Me2You].[MakeAllOldPostsInactive]";

        /// <summary>
        /// Stored Procedure to update a post once its delivered.
        /// </summary>
        public const string UpdatePostToDelivered = "[Me2You].[UpdatePostToDelivered]";

        /// <summary>
        /// Stored procedrue to update a post to the deleted status
        /// </summary>
        public const string UpDatePostToDeleted = "[Me2You].[UpdatePostToDeletedStatus]";

        /// <summary>
        /// Stored procedrue to update a post to the active status and set a new expiration.
        /// </summary>
        public const string UpDatePostToActiveAndUpdateExpiration = "[Me2You].[UpdatePostToActiveAndUpdateExpiration]";

        /// <summary>
        /// Stored procedure to get 'item request' posts in a category.
        /// </summary>
        public const string GetAllItemRequestPostsForCategory = "[Me2You].[GetAllItemRequestPostsInCategory]";

        /// <summary>
        /// Stored procedure to get all 'item request' posts.
        /// </summary>
        public const string GetAllItemRequestPosts = "[Me2You].[GetAllItemRequestPosts]";

        //Picture Stored Procedure Area----------------------------------------------------------------

        /// <summary>
        /// Stored procedure to select the subcategories for a parent category.
        /// </summary>
        public const string InsertPicture = "[Me2You].[InsertPicture]";      

        /// <summary>
        /// Stored procedure to select the Latest post by a user.
        /// </summary>
        public const string SelectPicturesForPost = "[Me2You].[SelectPicturesForPost]";

        /// <summary>
        /// Stored procedure to remove a photo from the post
        /// </summary>
        public const string RemovePhoto = "[Me2You].[RemovePicture]";

        //Event Stored Procedure Area-------------------------------------------------------------------

        /// <summary>
        /// Stored procedure to insert an event.
        /// </summary>
        public const string InsertEvent = "[Me2You].[InsertEvent]";

     
        /// <summary>
        /// Stored procedure to get all events from db for categoryid and that are 'active
        /// </summary>
        public const string GetAllEventsForCategory = "[Me2You].[GetAllEventsForCategory]";

        /// <summary>
        /// Stored procedure to get a particular event by its id 
        /// </summary>
        public const string GetEventByEventId = "[Me2You].[GetEventByEventId]";

        /// <summary>
        /// Stored procedure to get pictures for a particular event
        /// </summary>
        public const string GetEventPostPictures = "[Me2You].[GetEventPostPictures]";

        /// <summary>
        /// Stored procedure to insert a ticket claim
        /// </summary>
        public const string InsertTicketClaim = "[Me2You].[InsertTicketClaim]";

        /// <summary>
        /// Stored procedure to get all people who want to claim a ticket
        /// </summary>
        public const string GetTicketClaimsByEventId = "[Me2You].[GetTicketClaimsByEventId]";

        /// <summary>
        /// Stored procedure to get EventPreviews for event carousel 
        /// </summary>

        public const string GetAllEventsForCarousel = "[Me2You].[GetAllEventsForCarousel]";

        /// <summary>
        /// Stored procedure to Update an Event
        /// </summary>
        public const string UpdateEvent = "[Me2You].[UpdateEvent]";

        /// <summary>
        /// Stored procedure to Get All Events, no matter that status 
        /// </summary>
        public const string GetAllEvents = "[Me2You].[GetAllEvents]";

        /// <summary>
        /// Stored procedure to Get All Events, no matter that status 
        /// </summary>
        public const string GetAllActiveEvents = "[Me2You].[GetAllActiveEvents]";

        /// <summary>
        /// Stored procedure to get Event Info along with ticket claim count
        /// </summary>
        public const string GetTicketClaimCountForEvent = "[Me2You].[GetTicketClaimCountForEvent]";

        /// <summary>
        /// Stored procedure to update event post status 
        /// </summary>
        public const string UpdateEventPostStatus = "[Me2You].[UpdateEventPostStatus]";

        /// <summary>
        /// Stored procedure to insert a ticket winner into the ticketwinner table.
        /// </summary>
        public const string InsertTicketWinner = "[Me2You].[InsertTicketWinner]";

        /// <summary>
        /// Stored procedure that totals the number of ticket wins for an individual.
        /// </summary>
        public const string GetTotalTicketWinsForUser = "[Me2You].[GetTotalWinsForIndividual]";

        /// <summary>
        /// Gets the total number of times an individual has raised their hand.
        /// </summary>
        public const string GetTotalHandRaisesForIndividual = "[Me2You].[GetNumberOfHandRaisesForIndividual]";

        /// <summary>
        /// Updates the number of winners remaining for an event.
        /// </summary>
        public const string UpdateWinsRemaining = "[Me2You].[UpdateRemainingWinsForEvent]";

        /// <summary>
        /// Gets all of the current winners for an event.
        /// </summary>
        public const string GetAllWinnersForEvent = "[Me2You].[GetAllWinnersForEvent]";

        /// <summary>
        /// Gets all non winners for an event. (raised hand but did not win)
        /// </summary>
        public const string GetAllNonWinnersForEvent = "[Me2You].[GetAllNonWinnersForEvent]";

        //Generic Stored Procedure Area-----------------------------------------------------------------------------------

        /// <summary>
        /// Stored procedure to select a user.
        /// </summary>
        public const string SelectUser = "[Me2You].[SelectUser]";

        /// <summary>
        /// Stored procedure to get email verbiage.
        /// </summary>
        public const string GetEmailTemplate = "[Me2You].[GetEmailTemplate]";


        /// <summary>
        /// Stored proc to get a list of all admins
        /// </summary>
        public const string GetAllAdmins = "[Me2You].[GetAllAdmins]";

        /// <summary>
        /// Stored proc send an email
        /// </summary>
        public const string SendEmail = "[dbo].[USFS_sp_sendEmail]";
        /// <summary>
        /// Stored proc to return bool if a user is has admin rights or not
        /// </summary>
        public const string CheckAdminRights = "[Me2You].[CheckAdminRights]";

    }
}
