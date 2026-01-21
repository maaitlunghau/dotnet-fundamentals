using _13_school_management_system.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _13_school_management_system.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;
        public StudentController(IStudentRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _repo.GetAllStudentsAsync();
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
                return RedirectToAction(nameof(Index));
            }

            return View(stu);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            await _repo.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
