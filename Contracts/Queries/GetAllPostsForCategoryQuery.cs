using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    public class GetAllPostsForCategoryQuery : IQuery<IEnumerable<PostPreview>>
    {

        public Category category;

        public GetAllPostsForCategoryQuery(Category Category)
        {
            category = Category;
        }
    }
}
