using SearchPaginationEnd.Models;

namespace SearchPaginationEnd.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> ReadCategories();
    }
}
