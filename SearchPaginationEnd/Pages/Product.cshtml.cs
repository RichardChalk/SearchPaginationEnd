using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SearchPaginationEnd.Models;
using SearchPaginationEnd.Services;
using static SearchPaginationEnd.Pages.CategoryModel;

namespace SearchPaginationEnd.Pages
{
    public class ProductModel : PageModel
    {
        public ProductModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductViewModel ProductVM { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public void OnGet(int prodId, int catId)
        {
            CategoryId = catId;
            CategoryName = _categoryService.ReadCategories()
                .First(c => c.CategoryId == catId).CategoryName;

            ProductVM = _productService.ReadProduct(prodId);
        }
    }
}
