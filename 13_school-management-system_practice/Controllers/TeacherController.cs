using _13_school_management_system_practice.Models;
using _13_school_management_system_practice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _13_school_management_system_practice.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _repo;
        public TeacherController(ITeacherRepository repo) => _repo = repo;


        [HttpGet]
        public async Task<IActionResult> Index(string? department)
        {
            var allTeachers = await _repo.GetAllTeachersAsync();
            var teachers = allTeachers;

            if (!string.IsNullOrEmpty(department))
            {
                teachers = teachers.Where(t => t.Department == department);
            }

            ViewBag.Departments = allTeachers
                .Select(t => t.Department)
                .Distinct()
                .ToList();

            ViewBag.SelectedDepartment = department;

            return View(teachers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher? teacher)
        {
            if (!ModelState.IsValid) return View();

            await _repo.CreateNewTeacherAsync(teacher);
            TempData["message"] = "Thêm giảng viên mới thành công.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var allTeachers = await _repo.GetAllTeachersAsync();
            var teacher = await _repo.GetTeacherByIdAsync(id);

            ViewBag.OtherTeachers = allTeachers
                .Where(t => t.Id != teacher?.Id)
                .ToList();

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teacher? teacher)
        {
            if (!ModelState.IsValid) return View();

            await _repo.UpdateTeacherAsync(teacher);
            TempData["message"] = "Cập nhật giảng viên thành công.";

            return RedirectToAction(nameof(Index));
        }
    }
}
