using _01_getting_started.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01_getting_started.Controllers
{
    public class EmployeeController : Controller
    {
        private DataContext _dbContext;
        public EmployeeController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // keyword "Task" để nói với .NET: method này sẽ chạy bất đồng bộ nhé
        // và sẽ trả kết quả trong tương lai

        // keyword "ActionResult" để nói với .NET: method này sẽ trả về 1 HTTP response hợp lệ

        // => nói với .NET rằng: 
        // method này là Action bất đồng bộ, trả về kết quả HTTP
        public async Task<ActionResult> Index()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return View(employees);
        }

        // keyword "IActionResult" là: một interface đại diện cho kết quả về một HTTP request 
        // nói với .NET rằng: method này là 1 dạng HTTP response hợp lệ
        // nhưng cụ thể trả về cái gì / dạng gì thì để runtime (body) quyết định
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(employee);
        }
    }
}