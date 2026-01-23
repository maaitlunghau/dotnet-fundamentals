using _14_library_management_system_practice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _14_library_management_system_practice.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repo;
        public BookController(IBookRepository repo) => _repo = repo;


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await _repo.getAllBooksAsync();
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, string? isbn)
        {
            var book = await _repo.GetBookByIdAsync(id);
            if (book is null) return NotFound();

            if (string.IsNullOrWhiteSpace(isbn) || !isbn.Equals(book.ISBN))
            {
                TempData["Error"] = "ISBN không đúng. Không thể xoá!";
                return RedirectToAction(nameof(Index));
            }

            await _repo.DeleteBookAsync(id);
            TempData["Success"] = "Đã xoá sách thành công.";

            return RedirectToAction(nameof(Index));
        }
    }
}