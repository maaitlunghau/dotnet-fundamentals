using _08_unit_of_work.Models;
using _08_unit_of_work.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _08_unit_of_work.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _unitOfWork.Orders.GetAllOrdersAsync();
            return View(orders);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var products = await _unitOfWork.Products.GetAllProductsAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            try
            {
                var product = await _unitOfWork.Products.GetProductByIdAsync(order.ProductId);
                if (product != null)
                {
                    order.TotalAmount = order.Quantity * product.Price;
                    order.OrderDate = DateTime.Now;

                    // start transaction before save chanages
                    await _unitOfWork.BeginTransactionAsync();

                    await _unitOfWork.Orders.AddOrderAsync(order);

                    product.Quantity -= order.Quantity;
                    if (product.Quantity <= 0)
                    {
                        throw new InvalidOperationException("Product quantity is not enough!"); // hoặc Exception
                    }
                    await _unitOfWork.Products.UpdateProduct(product);

                    // complete transaction
                    bool result = await _unitOfWork.CompleteAsync();

                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

                ViewBag.message = "Something went wrong!";
                return View();
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, $"Rollback: {ex.Message}");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}