using _10_dto_many_to_many.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _10_dto_many_to_many.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _dbContext;
        /// <summary>
        /// Initializes a new instance of <see cref="CourseController"/> using the specified data context.
        /// </summary>
        /// <param name="dbContext">The Entity Framework data context used to access and persist Course entities.</param>
        public CourseController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Displays a view containing all courses retrieved from the database.
        /// </summary>
        /// <returns>A view populated with the list of Course entities.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _dbContext.Courses.ToListAsync();
            return View(courses);
        }

        /// <summary>
        /// Displays the form for creating a new course.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> that renders the course creation view.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Adds the provided course to the database and redirects to the index action.
        /// </summary>
        /// <param name="course">The Course to create and persist.</param>
        /// <returns>A redirect to the Index action.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}