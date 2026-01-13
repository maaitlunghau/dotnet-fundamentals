using _08_unit_of_work_practice.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _08_unit_of_work_practice.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var products = await _productRepository.GetAllProductAsync();
            ViewBag.Products = new SelectList(products, "Id", "Name"); // value, field-to-display

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                var product = await _productRepository.GetProductByIdAsync(order.ProductId);

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

                    await _orderRepository.AddOrderAsync(order);
                    return RedirectToAction(nameof(Index));
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.UpdateOrderAsync(order);
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
