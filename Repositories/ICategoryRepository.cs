using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetSubCategoriesByParentCategoryId(int categoryId);
    }
}
