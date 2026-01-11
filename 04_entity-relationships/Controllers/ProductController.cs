using System.Net.Http.Headers;
using _04_entity_relationships.Models;
using _04_entity_relationships.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _04_entity_relationships.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepositor;

        public ProductController(IProductRepository productRepository,
                                ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepositor = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var catetories = await _categoryRepositor.GetAllCategoriesAsync();

            // Select(...): lấy từ danh sách A (categories) thành một danh sách mới với các trường mình muốn trong danh sách A 
            var itemsForDropdown = catetories.Select(c => new
            {
                c.Id,
                NameIdDisplay = $"{c.Name} - {c.Id}"
            }).ToList();

            ViewBag.categoriesData = new SelectList(itemsForDropdown, "Id", "NameIdDisplay");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddProAsync(product);
                return RedirectToAction("Index");
            }

            var categories = await _categoryRepositor.GetAllCategoriesAsync();
            var ItemsForDropdown = categories.Select(c => new
            {
                c.Id,
                NameIdDisplay = $"{c.Name} - {c.Id}"
            }).ToList();

            ViewBag.categoriesData = new SelectList(ItemsForDropdown, "Id", "NameIdDisplay");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetProByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = await _categoryRepositor.GetAllCategoriesAsync();
            var itemsForDropdown = categories.Select(c => new
            {
                c.Id,
                NameIdDisplay = $"{c.Name} - {c.Id}"
            }).ToList();

            ViewBag.categoriesData = new SelectList(itemsForDropdown, "Id", "NameIdDisplay", product.CateId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.EditProAsync(product);
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryRepositor.GetAllCategoriesAsync();
            var itemsForDropdown = categories.Select(c => new
            {
                c.Id,
                NameIdDisplay = $"{c.Name} - {c.Id}"
            }).ToList();

            ViewBag.categoriesData = new SelectList(itemsForDropdown, "Id", "NameIdDisplay", product.CateId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteProAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
