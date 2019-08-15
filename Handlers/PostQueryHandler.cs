#region Copyright
//------------------------------------------------------------------------------------------
// <copyright file="PostQueryHandler.cs" company="United Shore Financial Services LLC.">
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

using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.Contracts.Queries;
using USFS.Domain.Me2U.DTO;
using USFS.Domain.Me2U.Repositories;

namespace USFS.Domain.Me2U.Handlers
{
    /// <summary>
    /// Class for the Post query handlers.
    /// </summary>
    public class PostQueryHandler : IQueryHandler<GetAllPostsBySearchQuery, IEnumerable<PostPreview>>, IQueryHandler<GetAllPostsForCategoryQuery, IEnumerable<PostPreview>>, 
                                    IQueryHandler<GetPostByPostIdQuery, Post>, IQueryHandler<GetRecentPostsForCarouselQuery, IEnumerable<PostPreview>>, 
                                    IQueryHandler<GetLatestPostByUserQuery, Post>, IQueryHandler<SelectPicturesForPostQuery, List<Picture>>, 
                                    IQueryHandler<GetAllPostsForSubCategoryQuery, IEnumerable<PostPreview>>, IQueryHandler<SelectAllPostsByUserQuery, List<Post>>, IQueryHandler<SelectAllPostClaimsByUserQuery, List<PostClaim>>,
                                    IQueryHandler<SelectAllPostClaimsByUserWithinThirtyDaysQuery, List<PostClaim>>, IQueryHandler<GetAllItemRequestPostsForCategoryQuery, IEnumerable<PostPreview>>
                                    , IQueryHandler<GetAllItemRequestPostsQuery, IEnumerable<PostPreview>>
    {
        /// <summary>
        /// The post repository, contains methods for accessing the database
        /// </summary>
        private readonly IPostRepository postRepository;

        /// <summary>
        /// Constructor for PostQueryHandler
        /// </summary>
        /// <param name="postRepository">the post repository</param>
        public PostQueryHandler(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        /// <summary>
        /// Handler for GetAllPostsBySearchQuery query
        /// </summary>
        /// <param name="query">the GetAllPostsBySearch Query</param>
        /// <returns>a collection of post preview's for the search</returns>
        public IEnumerable<PostPreview> Handle(GetAllPostsBySearchQuery query)
        {
            return postRepository.LoadAllPostsForSearchStringFixed(query.SearchText);
        }

        /// <summary>
        /// Handler for GetAllPostsForCategoryQuery query
        /// </summary>
        /// <param name="query">the GetAllPostsForCategory Query</param>
        /// <returns>a collection of post previews to display for a selected category</returns>
        public IEnumerable<PostPreview> Handle(GetAllPostsForCategoryQuery query)
        {
            return postRepository.GetAllPostsForCategoryFixed(query.category);
        }

        /// <summary>
        /// Handler for GetAllPostsForSubCategoryQuery query
        /// </summary>
        /// <param name="query">the GetAllPostsForSubCategory Query</param>
        /// <returns>a collection of post previews for a subcategory</returns>
        public IEnumerable<PostPreview> Handle(GetAllPostsForSubCategoryQuery query)
        {
            return postRepository.GetAllPostsForSubCategory(query.category);
        }

        /// <summary>
        /// Handler for GetPostByPostIdQuery query
        /// </summary>
        /// <param name="query">the GetPostByPostId Query</param>
        /// <returns>the post information associated with a post id</returns>
        public Post Handle(GetPostByPostIdQuery query)
        {
            return postRepository.GetPostByPostId(query.PostId);
        }

        /// <summary>
        /// Handler for GetRecentPostsForCarouselQuery query
        /// </summary>
        /// <param name="query">the GetRecentPostsForCarousel Query</param>
        /// <returns>a collection of post previews to display in the carousel</returns>
        public IEnumerable<PostPreview> Handle(GetRecentPostsForCarouselQuery query)
        {
            return postRepository.GetRecentPostsForCarousel();
        }

        /// <summary>
        /// Handler for GetLatestsPostByUserQuery query
        /// </summary>
        /// <param name="query">the GetLatestPostByUser Query</param>
        /// <returns>a post object that contains the data from the most recent post for an individual</returns>
        public Post Handle(GetLatestPostByUserQuery query)
        {
            return postRepository.GetLatestPostByUser(query.username);
        }

        /// <summary>
        /// Handler for SelectPicturesForPostQuery query
        /// </summary>
        /// <param name="query">the SelectPicturesForPost Query</param>
        /// <returns>a collection of inages associated with a post</returns>
        public List<Picture> Handle(SelectPicturesForPostQuery query)
        {
            return postRepository.SelectPicturesForPost(query.PostId);
        }

        /// <summary>
        /// Handler for SelectAllPostsByUserQuery query
        /// </summary>
        /// <param name="query">the SelectAllPostsByUser Query</param>
        /// <returns>a collection of posts from a specific user</returns>
        public List<Post> Handle(SelectAllPostsByUserQuery query)
        {
            return postRepository.SelectAllPostsByUser(query.LoginName);
        }

        /// <summary>
        /// Handler for SelectAllPostClaimsByUserQuery query
        /// </summary>
        /// <param name="query">the SelectAllPostClaimsByUser Query</param>
        /// <returns>a collection of items claimed by a user</returns>
        public List<PostClaim> Handle(SelectAllPostClaimsByUserQuery query)
        {
            return postRepository.SelectAllPostClaimsByUser(query.LoginName);
        }

        /// <summary>
        /// Handler for SelectAllPostClaimsByUserWithinThirtyDaysQuery query
        /// </summary>
        /// <param name="query">the SelectAllPostClaimsByUserWithinThirtyDays Query</param>
        /// <returns>a collection of post claims for an individual in the last 30 days</returns>
        public List<PostClaim> Handle(SelectAllPostClaimsByUserWithinThirtyDaysQuery query)
        {
            return postRepository.SelectAllPostClaimsByUserWithinThirtyDays(query.LoginName);
        }

        /// <summary>
        /// Handler for the Get All Looking For Posts For Category query
        /// </summary>
        /// <param name="query">the data for the query</param>
        /// <returns>a collection of previews for all 'looking for' items in a cetegory.</returns>
        public IEnumerable<PostPreview> Handle(GetAllItemRequestPostsForCategoryQuery query)
        {
            return postRepository.GetAllItemRequestPostsForCategory(query.Category);
        }

        /// <summary>
        /// Handler for the Get all Item Request Post Query
        /// </summary>
        /// <param name="query">the GetAllITemRequestPosts Query</param>
        /// <returns>a collection of post previews for all of the item request posts</returns>
        public IEnumerable<PostPreview> Handle(GetAllItemRequestPostsQuery query)
        {
            return postRepository.GetAllItemRequestPosts();
        }
    }
}
