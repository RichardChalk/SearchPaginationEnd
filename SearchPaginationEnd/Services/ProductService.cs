using SearchPaginationEnd.Models;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static SearchPaginationEnd.Pages.CategoryModel;

namespace SearchPaginationEnd.Services
{
    public class ProductService : IProductService
    {
        private readonly NorthwindContext _dbContext;
        public ProductService(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> ReadProducts(
            int categoryId, string sortColumn, string sortOrder, int page, string q)
        {
            var query = _dbContext.Products
                .Where(p => p.Category.CategoryId == categoryId);

            if (!string.IsNullOrEmpty(q))
            {
                query = query
                    .Where(p => p.ProductName.Contains(q) ||
                    p.Supplier.CompanyName.Contains(q));
            }

            if (string.IsNullOrEmpty(sortOrder))
                sortOrder = "asc";
            if (string.IsNullOrEmpty(sortColumn))
                sortColumn = "ProductName";

            if (sortColumn == "ProductName")
            {
                if (sortOrder == "desc")
                    query = query.OrderByDescending(p => p.ProductName);
                else
                    query = query.OrderBy(p => p.ProductName);
            }
            if (sortColumn == "UnitPrice")
            {
                if (sortOrder == "desc")
                    query = query.OrderByDescending(p => p.UnitPrice);
                else
                    query = query.OrderBy(p => p.UnitPrice);
            }
            if (sortColumn == "UnitsInStock")
            {
                if (sortOrder == "desc")
                    query = query.OrderByDescending(p => p.UnitsInStock);
                else
                    query = query.OrderBy(p => p.UnitsInStock);
            }

            var firstItemIndex = (page - 1) * 5; // 5 är page storlek

            query = query.Skip(firstItemIndex);
            query = query.Take(5); // 5 är page storlek

            return query.ToList();
        }

        public ProductViewModel ReadProduct(int productId)
        {
            var prodDb = _dbContext.Products
                .First(p => p.ProductId == productId);

            var prodVm = new ProductViewModel()
            {
                Id= prodDb.ProductId,
                Name = prodDb.ProductName,
                UnitPrice = prodDb.UnitPrice.Value,
                UnitInStock = prodDb.UnitsInStock.Value
            };

            return prodVm;
        }
    }
}
