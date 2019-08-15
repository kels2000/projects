using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USFS.Domain.Me2U.DTO
{
    public class Category
    {
        /// <summary>
        /// Description of the Category
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Database ID of the Category 
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Database ID of the SubCategory 
        /// </summary>
        public int SubCategoryId { get; set; }


        public Category()
        {

        }

        public Category(int categoryId)
        {
            CategoryId = categoryId;
        }

        public Category(int categoryId, int subCategoryId)
        {
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
        }

    }
}
