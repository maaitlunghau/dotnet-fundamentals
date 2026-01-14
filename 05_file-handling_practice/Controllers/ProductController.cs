using _05_file_handling_practice.Models;
using _05_file_handling_practice.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _05_file_handling_practice.Controllers
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product.Image == null)
            {
                ModelState.AddModelError("ImageUrl", "File không tồn tại!");
                return View(product);
            }

            // lấy tên file
            var fileName = Guid.NewGuid() + product.Image.FileName;

            // lấy địa chỉ thư mục chứa file
            var folderFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(folderFilePath))
            {
                Directory.CreateDirectory(folderFilePath);
            }

            // lập trình khối
            // ghi file từ RAM xuống thư mục ổ đĩa
            // FileMode: ghi file mới, nếu file đã tồn tại thì ghi đè
            string fileNamePath = Path.Combine(folderFilePath, fileName.TrimStart('/'));
            using (var fileStream = new FileStream(fileNamePath, FileMode.Create))
            {
                await product.Image.CopyToAsync(fileStream);
            }

            product.ImageUrl = "/images/" + fileName;

            if (ModelState.IsValid)
            {
                await _repo.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            var existingProduct = await _repo.GetProductByIdAsync(product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (product.Image != null)
            {
                // xoá file cũ
                if (!string.IsNullOrEmpty(existingProduct.ImageUrl))
                {
                    var oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                // lấy tên file mới
                var newFileName = Guid.NewGuid() + "-" + product.Image.FileName;

                // lấy tên folder chứa file mới
                var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // lập trình khối
                // mục đích: ghi file từ RAM xuống ổ đĩa
                // FileMode: tạo mới File hoặc ghi đè
                var filePath = Path.Combine(folderPath, newFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await product.Image.CopyToAsync(stream);
                }

                existingProduct.ImageUrl = "/images/" + newFileName;
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            await _repo.UpdateProductAsync(existingProduct);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            await _repo.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
