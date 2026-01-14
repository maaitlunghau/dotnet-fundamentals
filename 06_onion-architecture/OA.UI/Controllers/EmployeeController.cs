using Microsoft.AspNetCore.Mvc;
using OA.Domain.Model;
using OA.Service.Services;

namespace OA.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
            => _employeeService = employeeService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employess = await _employeeService.GetAll();
            ViewBag.message = TempData["message"] as string ?? null;

            return View(employess);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Create(employee);
                TempData["message"] = "Employee created successfully";

                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var existingEmployee = await _employeeService.GetById(id);
            if (existingEmployee == null) return NotFound();

            ViewBag.message = TempData["message"] as string ?? null;

            return View(existingEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Update(employee);
                TempData["message"] = "Employee updated successfully";

                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeService.Delete(id);
            TempData["message"] = "Employee deleted successfully";

            return RedirectToAction(nameof(Index));
        }
    }
}
