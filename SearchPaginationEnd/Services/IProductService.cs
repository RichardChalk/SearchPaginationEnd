using SearchPaginationEnd.Models;

namespace SearchPaginationEnd.Services
{
    public interface IProductService
    {
        IEnumerable<Product> ReadProducts(
            int categoryId, string sortColumn, string sortOrder, int page);
    }
}
