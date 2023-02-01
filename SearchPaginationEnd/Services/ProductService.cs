using SearchPaginationEnd.Models;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            int categoryId, string sortColumn, string sortOrder, int page)
        {
            var query = _dbContext.Products
                .Where(p => p.Category.CategoryId == categoryId);

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
            return query.ToList();
        }
    }
}
