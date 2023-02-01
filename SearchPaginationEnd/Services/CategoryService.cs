using SearchPaginationEnd.Models;

namespace SearchPaginationEnd.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly NorthwindContext _dbContext;

        public CategoryService(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Category> ReadCategories()
        {
            return _dbContext.Categories;
        }
    }
}
