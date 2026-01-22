using _14_library_management_system.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _14_library_management_system.Controllers
{
    public class UserController : Controller
    {
        private readonly IBookRepository _repo;
        public UserController(IBookRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _repo.GetAllBooksAsync();
            return View(books);
        }
    }
}
