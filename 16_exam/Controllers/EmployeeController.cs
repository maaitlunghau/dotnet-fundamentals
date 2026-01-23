using _16_exam.Models;
using _16_exam.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _16_exam.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(
            IEmployeeRepository repo,
            IWebHostEnvironment webHostEnvironment
        )
        {
            _repo = repo;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _repo.GetAllEmployeeAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee? emp)
        {
            if (!ModelState.IsValid) return View(emp);
            if (emp?.PhotoHandling is null)
                ModelState.AddModelError("PhotoHandling", "Vui lòng gửi ảnh.");

            string fileName = Guid.NewGuid() + "-" + emp?.PhotoHandling?.FileName;
            emp?.Photo = "/images/employees/" + fileName;

            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images/employees");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName.TrimStart('/'));
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await emp!.PhotoHandling!.CopyToAsync(fileStream);
            }

            await _repo.CreateNewEmployeeAsync(emp);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrDelete(int? id)
        {
            if (id == null) return View(new Employee());

            var emp = await _repo.GetEmployeeByIdAsync(id);
            if (emp is null) return NotFound();

            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrDelete(Employee? emp, string action)
        {
            if (!ModelState.IsValid) return View(emp);

            var existingEmp = await _repo.GetEmployeeByIdAsync(emp?.Id);
            if (existingEmp == null) return NotFound();

            existingEmp.LastName = emp?.LastName;
            existingEmp.FirstName = emp?.FirstName;
            existingEmp.BirthDate = emp?.BirthDate;
            existingEmp.Skills = emp?.Skills;

            if (emp?.PhotoHandling != null)
            {
                if (!string.IsNullOrEmpty(existingEmp.Photo))
                {
                    var oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, existingEmp.Photo.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                string fileName = Guid.NewGuid() + "-" + emp.PhotoHandling.FileName;
                existingEmp.Photo = "/images/employees/" + fileName;

                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images/employees");
                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await emp.PhotoHandling.CopyToAsync(fileStream);
                }
            }

            await _repo.UpdateEmployeeAsync(existingEmp);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee? emp)
        {
            var existingEmployee = await _repo.GetEmployeeByIdAsync(emp?.Id);
            if (existingEmployee == null) return NotFound();

            if (emp?.PhotoHandling != null)
            {
                if (!string.IsNullOrEmpty(existingEmployee.Photo))
                {
                    var oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, existingEmployee.Photo.TrimStart('/'));
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                var newFileName = Guid.NewGuid() + "-" + emp.PhotoHandling.FileName;

                var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images/employees");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = Path.Combine(folderPath, newFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await emp.PhotoHandling.CopyToAsync(stream);
                }

                existingEmployee.Photo = "/images/employees/" + newFileName;
            }

            existingEmployee.LastName = emp?.LastName;
            existingEmployee.FirstName = emp?.FirstName;
            existingEmployee.BirthDate = emp?.BirthDate;
            existingEmployee.Skills = emp?.Skills;

            await _repo.UpdateEmployeeAsync(existingEmployee);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            var emp = await _repo.GetEmployeeByIdAsync(id);
            if (emp is null) return NotFound();

            if (!string.IsNullOrEmpty(emp.Photo))
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, emp.Photo.TrimStart('/'));
                if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
            }

            await _repo.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
