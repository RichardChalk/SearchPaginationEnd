using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SearchPaginationEnd.Models;
using SearchPaginationEnd.Services;

namespace SearchPaginationEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryService _categoryService;

        public IndexModel(ILogger<IndexModel> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public class CategoryViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public List<CategoryViewModel> Categories { get; set; }

        public void OnGet()
        {
            Categories = _categoryService.ReadCategories()
                .Select(c=> new CategoryViewModel
                {
                    Id = c.CategoryId,
                    Name = c.CategoryName
                }).ToList();
        }
    }
}