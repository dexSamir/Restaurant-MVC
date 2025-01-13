using Microsoft.AspNetCore.Mvc;
using Restaurant.BL.Services.Interfaces;
using Restaurant.BL.VM.Category;

namespace Restaurant.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync()); 
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM vm)
        {
            if (!ModelState.IsValid)
                return View();
            await _service.CreateAsync(vm); 
            return RedirectToAction(nameof(Index));
        }
    }
}
