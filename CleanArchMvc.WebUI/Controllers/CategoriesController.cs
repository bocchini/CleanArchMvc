using Microsoft.AspNetCore.Mvc;
using CleanArchMvc.Application.Dtos;
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

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if(ModelState.IsValid)
            {
                await _category.Add(categoryDto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _category.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _category.Update(categoryDto);
                }
                catch (Exception) 
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _category.GetById(id);

            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = _category.GetById(id);
            if (category == null) return NotFound();
            await _category.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _category.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }
    }
}
