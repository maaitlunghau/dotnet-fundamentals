using _14_library_management_system_practice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _14_library_management_system_practice.Controllers
{
    public class UserController : Controller
    {
        private readonly IBookRepository _repo;
        public UserController(IBookRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _repo.getAllBooksAsync();
            return View(books);
        }
    }
}
