using _10_dto_many_to_many.DTO;
using _10_dto_many_to_many.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _10_dto_many_to_many.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly DataContext _dbContext;
        /// <summary>
        /// Initializes a new instance of <see cref="StudentCourseController"/> using the provided data context.
        /// </summary>
        /// <param name="dbContext">The application's <see cref="DataContext"/> used to access students, courses, and their associations.</param>
        public StudentCourseController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Displays a view with a list of students and their enrolled course titles.
        /// </summary>
        /// <returns>A view result containing a list of StudentIndexDTO objects, each with StudentId, Name, and a list of course titles.</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _dbContext.Students
                                        .Include(sc => sc.StudentCourses)
                                        .ThenInclude(c => c.Course)
                                        .Select(s => new StudentIndexDTO
                                        {
                                            StudentId = s.Id.ToString(),
                                            Name = s.Name,
                                            Courses = s.StudentCourses.Select(sc => sc.Course!.Title!).ToList()
                                        })
                                        .ToListAsync();
            return View(students);
        }

        /// <summary>
        /// Displays a form for assigning one or more courses to a student.
        /// </summary>
        /// <returns>A view populated with a StudentAssignCourseDTO containing lists of students and courses for selection.</returns>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var list = new StudentAssignCourseDTO
            {
                Students = await _dbContext.Students.Select(s => new StudentDTO
                {
                    StudentId = s.Id.ToString(),
                    Name = s.Name
                }).ToListAsync(),

                Courses = await _dbContext.Courses.Select(c => new CourseDTO
                {
                    CourseId = c.Id.ToString(),
                    Title = c.Title,
                    isSelected = false
                }).ToListAsync()
            };

            return View(list);
        }


        /// <summary>
        /// Handles the POST submission to assign one or more selected courses to a selected student.
        /// </summary>
        /// <param name="dto">DTO containing the selected student id and the collection of selected course ids.</param>
        /// <returns>
        /// When the model state is valid, returns the same view populated with <paramref name="dto"/>; 
        /// otherwise creates StudentCourse entries for each selected course, saves them to the database, and redirects to the Index action.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Create(StudentAssignCourseDTO dto)
        {
            // validate
            if (string.IsNullOrEmpty(dto.SelectedStudentId))
            {
                ModelState.AddModelError("", "Please select a student.");
            }
            if (dto.SelectedCourseId == null || dto.SelectedCourseId.Any())
            {
                ModelState.AddModelError("", "Vui lòng chọn ít nhất một khóa học.");
            }
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var studentCourses = dto.SelectedCourseId!.Select(courseId => new StudentCourse
            {
                StudentId = Guid.Parse(dto.SelectedStudentId!),
                CourseId = Guid.Parse(courseId)
            }).ToList();

            _dbContext.StudentCourses.AddRange(studentCourses);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}