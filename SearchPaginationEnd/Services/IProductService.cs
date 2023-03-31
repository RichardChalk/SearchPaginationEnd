using SearchPaginationEnd.Models;
using static SearchPaginationEnd.Pages.CategoryModel;

namespace SearchPaginationEnd.Services
{
    public interface IProductService
    {
        IEnumerable<Product> ReadProducts(
            int categoryId, string sortColumn, string sortOrder, int page, string q);

        ProductViewModel ReadProduct(int productId);
    }
}
