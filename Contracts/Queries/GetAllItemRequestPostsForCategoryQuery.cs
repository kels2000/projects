#region Copyright

//------------------------------------------------------------------------------------------
// <copyright file="GetAllItemRequestPostsForCategoryQuery.cs" company="United Shore Financial Services LLC.">
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

using USFS.Domain.Me2U.DTO;
using USFS.Core.Command;
using System.Collections.Generic;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// Query for GetAllItemRequestPostsForCategory
    /// </summary>
    public class GetAllItemRequestPostsForCategoryQuery : IQuery<IEnumerable<PostPreview>>
    {
        /// <summary>
        /// The id of the category to get posts for
        /// </summary>
        public Category Category { get; private set; }

        /// <summary>
        /// Construtor for GetAllItemRequestPostsForCategory query
        /// </summary>
        /// <param name="category">The id of the category to get posts for</param>
        public GetAllItemRequestPostsForCategoryQuery(Category category)
        {
            Category = category;
        }

    }
}
