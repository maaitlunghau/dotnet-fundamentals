using _15_product_management_system_practice.Models;
using _15_product_management_system_practice.Repository;

using Microsoft.AspNetCore.Mvc;

namespace _15_product_management_system_practice.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(
            IProductRepository repo,
            IWebHostEnvironment webHostEnvironment
        )
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
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product? pro)
        {
            if (!ModelState.IsValid) return View(pro);
            if (pro?.ImageHandling is null)
                ModelState.AddModelError("ImageHandling", "Vui lòng gửi ảnh.");

            string fileName = Guid.NewGuid() + "-" + pro?.ImageHandling?.FileName;
            pro?.Image = "/images/products/" + fileName;

            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName.TrimStart('/'));
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await pro!.ImageHandling!.CopyToAsync(fileStream);
            }

            await _repo.CreateProductAsync(pro);
            return RedirectToAction(nameof(Index));
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