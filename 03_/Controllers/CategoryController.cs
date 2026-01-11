using Microsoft.AspNetCore.Mvc;

namespace _03_;

public class CategoryController
{
    // private readonly ICategoryRepository _categoryRepository;

    // public CategoryController(ICategoryRepository categoryRepository)
    // {
    //     _categoryRepository = categoryRepository;
    // }

    // public async Task<IActionResult> Index()
    // {
    //     var categories = await _categoryRepository.GetAllCatesAsync();
    //     return View(categories);
    // }

    // [HttpGet]
    // [Route("/hack-di-anh/add")]
    // public IActionResult Create()
    // {
    //     return View();
    // }

    // [HttpPost]
    // //[ActionName("Create")]
    // [Route("/hack-di-anh/add")]
    // public async Task<IActionResult> Create(Category category)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         await _categoryRepository.AddCategAsync(category);
    //         return RedirectToAction(nameof(Index));
    //     }

    //     return View();
    // }
}
