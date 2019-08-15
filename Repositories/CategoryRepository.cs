using System.Collections.Generic;
using USFS.Core.Data;
using USFS.Domain.Me2U.Constants;
using USFS.Domain.Me2U.DTO;

namespace USFS.Domain.Me2U.Repositories
{
    public class CategoryRepsitory : ICategoryRepository
    {
        /// <summary>
        /// custom database object.
        /// </summary>
        private readonly DataRepository database;

        public CategoryRepsitory(DataRepository database)
        {
            this.database = database;
        }      

        public Category CategoryMapper(SqlReaderWrapper data, int rownum)
        {
            return new Category()
            {
                CategoryId = data.GetInt("CategoryID"),
                CategoryName = data.GetString("CategoryName")
            };
        }

        public IEnumerable<Category> GetSubCategoriesByParentCategoryId(int categoryId)
        {
            SqlStatement statement = new SqlStatement(StoredProcedures.GetSubCategoriesByParentCategoryId);
            statement.AddParameter("CategoryId", categoryId);
            return database.ExecuteStoredProc(statement, CategoryMapper);
        }
    }
}
