using Microsoft.AspNetCore.Mvc;
using CleanArchMvc.Application.Interfaces;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _category;

        public CategoriesController(ICategoryService category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _category.GetCategories());
        }
    }
}
