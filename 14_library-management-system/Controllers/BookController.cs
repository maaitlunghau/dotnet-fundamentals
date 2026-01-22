using _14_library_management_system.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _14_library_management_system.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repo;
        public BookController(IBookRepository repo) => _repo = repo;


        public async Task<IActionResult> Index()
        {
            var books = await _repo.GetAllBooksAsync();
            return View(books);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var book = await _repo.GetBookByIdAsync(id);
            if (book is null) return NotFound();

            await _repo.DeleteBookAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
