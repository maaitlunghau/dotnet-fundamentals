using System.Security.Cryptography;
using _05_file_handling.Models;
using _05_file_handling.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _05_file_handling.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductRepository productRepository,
                                IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _webHostEnvironment = webHostEnvironment;
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
            if (product.Image != null)
            {
                // lấy tên file (dựa vào file đã upload lên)
                // string fileName = DateTime.Now + "-" + product.Image.FileName;
                string fileName = Guid.NewGuid() + "-" + product.Image.FileName;

                // lấy địa chỉ thư mục chứa file
                string folderFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(folderFilePath))
                {
                    Directory.CreateDirectory(folderFilePath);
                }

                // lập trình khối
                // mục đích: ghi file từ RAM xuống thư mục / ổ đĩa
                // 
                // FileMode.Create: tạo file mới hoặc ghi đè (upload)
                // FileMode.CreateNew: tạo mới, nếu đã tồn taị -> error (tránh override)
                // FileMode.Open: mở file đã tồn tại (đọc file)
                // FileMode.OpenOrCreate: mở file nếu có, kco thì tạo mới (Log)
                // FileMode.Truncate: mở file & xoá nội dung (reset file)
                // FileMode.Append: ghi thêm vào cuối file (Log)
                string fileNamePath = Path.Combine(folderFilePath, fileName);
                using (var fileStream = new FileStream(fileNamePath, FileMode.Create))
                {
                    await product.Image.CopyToAsync(fileStream);
                }

                // lưu đường dẫn file vào file ImageUrl (để lưu vào database)
                product.ImageUrl = "/images/" + fileName;
            }
            else
            {
                ModelState.AddModelError("ImageUrl", "File is required");
            }

            if (ModelState.IsValid)
            {
                await _productRepository.CreateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product != null)
            {
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                await _productRepository.DeleteProductAsync(id);
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}