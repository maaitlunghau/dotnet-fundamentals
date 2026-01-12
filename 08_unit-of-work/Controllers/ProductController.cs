using _08_unit_of_work.Models;
using _08_unit_of_work.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _08_unit_of_work.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return View(products);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
