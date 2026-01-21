using _13_school_management_system.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _13_school_management_system.Controllers
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
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateTeacherAsync(teacher);
                TempData["message"] = "Tạo mới giáo viên thành công.";

                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var t = await _repo.GetTeacherByIdAsync(id);
            if (t == null) return NotFound();

            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _repo.UpdateTeacherAsync(teacher);
                TempData["message"] = "Cập nhật giáo viên thành công.";

                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            await _repo.DeleteTeacherAsync(id);
            TempData["message"] = "Đã xoá giáo viên thành công.";

            return RedirectToAction(nameof(Index));
        }
    }
}