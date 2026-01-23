using _14_library_management_system_practice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _14_library_management_system_practice.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repo;
        public BookController(IBookRepository repo) => _repo = repo;


        [HttpGet]
        public IActionResult Index()
        {
            var books = _repo.getAllBooksAsync();
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            await _repo.DeleteBookAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}