using _13_school_management_system.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _13_school_management_system.Controllers
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
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            await _repo.DeleteTeacherAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
