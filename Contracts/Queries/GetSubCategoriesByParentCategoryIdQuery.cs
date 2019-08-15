using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Contracts.Queries
{
    public class GetSubCategoriesByParentCategoryId : IQuery<IEnumerable<Category>>
    {

        public int CategoryId { get; set; }

        public GetSubCategoriesByParentCategoryId(int CategoryId)
        {
            this.CategoryId = CategoryId;
        }
    }
}
