using Microsoft.AspNetCore.Mvc;

namespace _04_file;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    // using IWebHostEnvironment to access wwwroot path
    // IWebHostEnvironment provides information about the web hosting environment an application is running in
    // so that we can save uploaded files there

    public ProductController(IProductRepository productRepository,
                             IWebHostEnvironment webHostEnvironment)
    {
        _productRepository = productRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productRepository.GetAllProductsAsync();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (product.ImageFile != null)
        {
            // string fileName = product.ImageFile.Name;
            // string fileName = Path.GetFileName(product.ImageFile.FileName);
            // string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(product.ImageFile.FileName);
            string fileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images"); // folder "images" in wwwroot
            string filePathImage = Path.Combine(filePath, fileName); // file path to save image
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            // lập trình khối bất đồng bộ: giải phóng tài nguyên đúng cách trong khi chờ đợi
            using (var fileStream = new FileStream(filePathImage, FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(fileStream);
            }
            // product.FilePath = filePath;
            product.FilePath = "/images/" + fileName;

            await _productRepository.CreateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ModelState.AddModelError("ImageFile", "Please select an image file.");
            // field, message
        }

        if (ModelState.IsValid)
        {

        }

        return View();
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productRepository.GetOneProductAsync(id);
        if (product != null)
        {
            if (!string.IsNullOrEmpty(product.FilePath))
            {
                // var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.FilePath.TrimStart('/'));
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, product.FilePath);

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                await _productRepository.DeleteProductAsync(id);
            }
        }

        return RedirectToAction(nameof(Index));
    }
}
