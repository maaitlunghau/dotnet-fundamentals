using _13_school_management_system_practice.Models;
using _13_school_management_system_practice.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Index()
        {
            var students = await _studentRepo.GetStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var allTeachers = await _teacherRepo.GetAllTeachersAsync();
            var teachers = allTeachers;

            ViewBag.Teachers = teachers
                .Select(t => t.TeacherName)
                .Distinct()
                .ToList();

            return View(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student? stu)
        {
            if (ModelState.IsValid == false) return View();

            await _studentRepo.CreateNewStudentAlongTeacher(stu);
            return RedirectToAction(nameof(View));
        }
    }
}
