using _12_dto_automapper_announcement.Models;
using _12_dto_automapper_announcement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _12_dto_automapper_announcement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateUserAsync(user);
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user is null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                await _repo.UpdateUserAsync(user);
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            await _repo.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
