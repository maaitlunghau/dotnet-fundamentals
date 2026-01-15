using _10_dto_many_to_many.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _10_dto_many_to_many.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _dbContext;
        /// <summary>
        /// Initializes a new instance of the StudentController class with the specified data context.
        /// </summary>
        /// <param name="dbContext">The DataContext used for database access.</param>
        public StudentController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Displays the index view populated with all students from the database.
        /// </summary>
        /// <returns>An IActionResult that renders a view with the retrieved student list as its model.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _dbContext.Students.ToListAsync();
            return View(students);
        }

        /// <summary>
        /// Displays the view for creating a new student.
        /// </summary>
        /// <returns>A view result that renders the student creation form.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Adds the provided student to the data store and redirects to the index view.
        /// </summary>
        /// <param name="student">The student entity to add.</param>
        /// <returns>A redirect to the Index action.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}