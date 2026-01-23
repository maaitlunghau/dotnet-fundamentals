using _13_school_management_system_practice.Models;
using _13_school_management_system_practice.Repositories;
using _13_school_management_system_practice.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _13_school_management_system_practice.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly ITeacherRepository _teacherRepo;
        public StudentController(IStudentRepository studentRepo,
                                ITeacherRepository teacherRepo)
        {
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string? teacherName)
        {
            var allStudents = await _studentRepo.GetStudentsAsync();
            var students = allStudents;

            if (!string.IsNullOrEmpty(teacherName))
            {
                students = students
                    .Where(stu => stu.Teacher?.TeacherName == teacherName)
                    .ToList();
            }

            ViewBag.Teachers = allStudents
                .Select(stu => stu.Teacher?.TeacherName)
                .Distinct()
                .ToList();

            ViewBag.SelectedTeacher = teacherName;

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teachers = await _teacherRepo.GetAllTeachersAsync();

            ViewBag.Teachers = teachers
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.TeacherName
                })
                .ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student stu)
        {
            if (!ModelState.IsValid)
            {
                var teachers = await _teacherRepo.GetAllTeachersAsync();
                ViewBag.Teachers = new SelectList(teachers, "Id", "TeacherName");

                return View(stu);
            }

            await _studentRepo.CreateNewStudentAlongTeacher(stu);
            TempData["message"] = "Thêm mới sinh viên thành công.";

            return RedirectToAction(nameof(Index));
        }
    }
}
