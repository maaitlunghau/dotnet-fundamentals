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
        public async Task<IActionResult> Index(
            string? search,
            string? sortBy,
            string? sortDir
        )
        {
            var allProducts = await _repo.GetAllProductsAsync();
            var products = allProducts;

            // filter
            if (!string.IsNullOrWhiteSpace(search))
            {
                products = products
                    .Where(prod => prod!.ProductName!.ToLower().Contains(search.ToLower()))
                    .OrderBy(prod => prod.ProductName)
                    .ToList();
            }

            // sort
            sortDir = sortDir == "asc" ? "asc" : "desc";

            products = sortBy switch
            {
                "name" => sortDir == "asc" ?
                    products.OrderBy(p => p.ProductName)
                    : products.OrderByDescending(p => p.ProductName),

                "price" => sortDir == "asc" ?
                    products.OrderBy(p => p.Price)
                    : products.OrderByDescending(p => p.Price),

                _ => products.OrderBy(p => p.ProductName)
            };

            ViewBag.sortBy = sortBy;
            ViewBag.sortDir = sortDir;

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
            var pro = await _repo.GetProductByIdAsync(id);
            if (pro is null) return NotFound();

            if (!string.IsNullOrEmpty(pro.Image))
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, pro.Image.TrimStart('/'));
                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
            }

            await _repo.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
