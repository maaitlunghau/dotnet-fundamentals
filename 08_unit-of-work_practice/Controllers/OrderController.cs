using _08_unit_of_work_practice.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _08_unit_of_work_practice.Controllers
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
            var orders = await _unitOfWork.OrderRepository.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var products = await _unitOfWork.ProductRepository.GetAllProductAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(order.ProductId);

                try
                {
                    if (product == null) throw new Exception("Product not found");
                    if (product.Quantity <= 0)
                    {
                        throw new InvalidOperationException("Product is out of stock");
                    }
                    if (order.Quantity <= 0)
                    {
                        throw new InvalidOperationException("Order quantity must be greater than 0");
                    }

                    product.Quantity -= order.Quantity;
                    if (product.Quantity < 0)
                    {
                        throw new InvalidOperationException("Product quantity is not enough to order");
                    }

                    order.TotalAmount = (double)(product.Price * order.Quantity);
                    order.OrderDate = DateTime.Now;

                    // start transaction (should start BEFORE save changes)
                    await _unitOfWork.BeginTransactionAsync();

                    await _unitOfWork.OrderRepository.AddOrderAsync(order);
                    await _unitOfWork.ProductRepository.UpdateProductAsync(product);

                    // complete transaction
                    bool result = await _unitOfWork.CompleteAsync();
                    if (result) return RedirectToAction(nameof(Index));

                }
                catch (InvalidOperationException ioe)
                {
                    return StatusCode(500, ioe.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            return View(order);
        }
    }
}
