using System.Collections.Generic;
using USFS.Core.Command;
using USFS.Domain.Me2U.Contracts.Queries;
using USFS.Domain.Me2U.DTO;
using USFS.Domain.Me2U.Repositories;

namespace USFS.Domain.Me2U.Handlers
{
    public class CategoryQueryHandler : IQueryHandler<GetSubCategoriesByParentCategoryId, IEnumerable<Category>>
    {

        private ICategoryRepository CategoryRepository;

        public CategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }   

        public IEnumerable<Category> Handle(GetSubCategoriesByParentCategoryId query)
        {
            return CategoryRepository.GetSubCategoriesByParentCategoryId(query.CategoryId);
        }
    }
}
