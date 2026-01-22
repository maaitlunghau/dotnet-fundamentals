using _15_product_management_system.Models;
using _15_product_management_system.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _15_product_management_system.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductRepository repo, IWebHostEnvironment webHostEnvironment)
        {
            _repo = repo;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _repo.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product? pro)
        {
            if (pro?.ImageHandling == null)
            {
                ModelState.AddModelError("ImageHandling", "Please select an image.");
            }

            if (ModelState.IsValid)
            {
                string fileName = Guid.NewGuid() + pro?.ImageHandling?.FileName;
                pro!.Image = "/images/" + fileName;

                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await pro.ImageHandling!.CopyToAsync(fileStream);
                }

                await _repo.CreateProductAsync(pro);
                return RedirectToAction(nameof(Index));
            }

            return View(pro);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            var prod = await _repo.GetProductByIdAsync(id);
            if (prod is null) return NotFound();

            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product? pro)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateProductAsync(pro);
                return RedirectToAction(nameof(Index));
            }

            return View(pro);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            await _repo.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
