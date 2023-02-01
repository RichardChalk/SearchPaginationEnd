using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SearchPaginationEnd.Services;

namespace SearchPaginationEnd.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public CategoryModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public string CategoryName { get; set; }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitInStock { get; set; }
        }
        public List<ProductViewModel> Products { get; set; }

        public void OnGet(int categoryId)
        {
            CategoryName = _categoryService.ReadCategories()
                .First(c => c.CategoryId == categoryId).CategoryName;

            Products = _productService.ReadProducts(categoryId, null, null, 0)
                .Select(p => new ProductViewModel
                {
                    Id = p.ProductId,
                    Name = p.ProductName,
                    UnitPrice = p.UnitPrice.Value,
                    UnitInStock = p.UnitsInStock.Value,
                }).ToList();
        }
    }
}
