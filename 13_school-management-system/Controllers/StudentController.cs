using _13_school_management_system.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _13_school_management_system.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;
        public StudentController(IStudentRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index(string? teacherName)
        {
            var allStudents = await _repo.GetAllStudentsAsync();
            var students = allStudents;

            if (!string.IsNullOrEmpty(teacherName))
            {
                students = students.Where(s => s.Teacher?.TeacherName == teacherName);
            }

            ViewBag.Teachers = allStudents
                .Where(s => s.Teacher != null)
                .Select(s => s.Teacher!.TeacherName)
                .Distinct()
                .ToList();

            ViewBag.SelectedTeacher = teacherName;

            return View(students);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateStudentAsync(stu);
                TempData["message"] = "Tạo mới sinh viên thành công";

                return RedirectToAction(nameof(Index));
            }

            return View(stu);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student stu)
        {
            if (ModelState.IsValid)
            {
                await _repo.UpdateStudentAsync(stu);
                TempData["message"] = "Cập nhật sinh viên thành công";

                return RedirectToAction(nameof(Index));
            }

            return View(stu);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            await _repo.DeleteStudentAsync(id);
            TempData["message"] = "Đã xoá sinh viên thành công";

            return RedirectToAction(nameof(Index));
        }
    }
}
