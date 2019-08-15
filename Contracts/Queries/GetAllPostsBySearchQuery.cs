using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    /// <summary>
    /// Class to return all post previews for search text
    /// </summary>
    public class GetAllPostsBySearchQuery : IQuery<IEnumerable<PostPreview>>
    {
        public string SearchText { get; set; }

        /// <summary>
        /// Searching for posts query constructor
        /// </summary>
        public GetAllPostsBySearchQuery(string searchText)
        {
            SearchText = searchText;
        }

    }
}
