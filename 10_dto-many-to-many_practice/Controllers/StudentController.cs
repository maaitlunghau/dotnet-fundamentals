using _10_dto_many_to_many_practice.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _10_dto_many_to_many_practice.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _dbContext;
        public StudentController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {
            var students = await _dbContext.Students.ToListAsync();
            if (!string.IsNullOrWhiteSpace(search))
            {
                students = students.Where(stu => stu.Name!.ToLower().Contains(search.ToLower())).ToList();
            }

            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null) return NotFound();

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
