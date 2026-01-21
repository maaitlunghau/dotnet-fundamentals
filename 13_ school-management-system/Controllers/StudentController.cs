using _13__school_management_system.Models;
using _13__school_management_system.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace _13__school_management_system.Controllers
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
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateNewStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            var student = await _repo.GetStudentByIdAsync(id);
            if (student is null) return NotFound();

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                await _repo.EditStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            await _repo.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
