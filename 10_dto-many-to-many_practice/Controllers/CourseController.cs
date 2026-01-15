using _10_dto_many_to_many_practice.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _10_dto_many_to_many_practice.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _dbContext;
        public CourseController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {
            IQueryable<Course> query = _dbContext.Courses;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c => c.Title!.ToLower().Contains(search.ToLower()));
            }

            var courses = await query.ToListAsync();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Courses.AddAsync(course);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Courses.Update(course);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            if (course == null) return NotFound();

            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
