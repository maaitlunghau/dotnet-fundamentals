using _13__school_management_system.Models;
using _13__school_management_system.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _13__school_management_system.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _repo;

        public TeacherController(ITeacherRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var teachers = await _repo.GetAllTeachersAsync();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateNewTeacherAsync(teacher);
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var teacher = await _repo.GetTeacherByIdAsync(id);
            if (teacher is null) return NotFound();

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                await _repo.EditTeacherAsync(teacher);
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repo.DeleteTeacherAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
