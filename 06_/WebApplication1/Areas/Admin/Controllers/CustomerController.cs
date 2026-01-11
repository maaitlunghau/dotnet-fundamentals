using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Areas.Admin.Controllers;

[Area("Admin")]
public class CustomerController : Controller
{
    private readonly DataContext _dbContext;

    public CustomerController(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var customers = await _dbContext.Customers.ToListAsync();
        return View(customers);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(customer);
    }
}
