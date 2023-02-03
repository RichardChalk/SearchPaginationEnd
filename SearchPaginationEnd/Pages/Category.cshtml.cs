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
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitInStock { get; set; }
        }
        public List<ProductViewModel> Products { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int CurrentPage { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public string Q { get; set; }

        public void OnGet(int categoryId, string sortColumn, 
            string sortOrder, int pageNo, string q)
        {
            Q = q; // Söktext
            
            SortColumn= sortColumn;
            SortOrder= sortOrder;

            if (pageNo == 0)
                pageNo = 1;
            CurrentPage= pageNo;

            CategoryId = categoryId;

            CategoryName = _categoryService.ReadCategories()
                .First(c => c.CategoryId == categoryId).CategoryName;

            Products = _productService.ReadProducts(categoryId, sortColumn, 
                sortOrder, pageNo, q)
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
