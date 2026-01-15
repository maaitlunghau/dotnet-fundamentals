using _10_dto_many_to_many_practice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _10_dto_many_to_many_practice.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly DataContext _dbContext;
        public StudentCourseController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? search)
        {
            var data = await _dbContext.Students
                                    .Include(sc => sc.StudentCourses)
                                    .ThenInclude(c => c.Course)
                                    .Select(s => new StudentCourseIndexDTO
                                    {
                                        StudentId = s.Id.ToString(),
                                        StudentName = s.Name,
                                        Courses = s.StudentCourses.Select(c => c.Course!.Title!).ToList()
                                    })
                                    .ToListAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                data = data.Where(d =>
                    d.StudentName!.ToLower().Contains(search.ToLower()) ||
                    d.Courses!.Any(c => c.ToLower().Contains(search.ToLower()))
                ).ToList();
            }

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var list = new StudentCourseCreateDTO
            {
                Students = await _dbContext.Students.Select(s => new StudentDTO
                {
                    StudentId = s.Id.ToString(),
                    StudentName = s.Name
                }).ToListAsync(),

                Courses = await _dbContext.Courses.Select(c => new CourseDTO
                {
                    CourseId = c.Id.ToString(),
                    CourseName = c.Title
                }).ToListAsync()
            };

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCourseCreateDTO dto)
        {
            // validate 
            if (string.IsNullOrEmpty(dto.SelectedStudentId))
            {
                ModelState.AddModelError("SelectedStudentId", "Please select a student");
            }
            if (dto.SelectedCourseIds == null || !dto.SelectedCourseIds.Any())
            {
                ModelState.AddModelError("SelectedCourseIds", "Please select a course");
            }
            if (!ModelState.IsValid)
            {
                dto.Students = await _dbContext.Students.Select(s => new StudentDTO
                {
                    StudentId = s.Id.ToString(),
                    StudentName = s.Name
                }).ToListAsync();

                dto.Courses = await _dbContext.Courses.Select(c => new CourseDTO
                {
                    CourseId = c.Id.ToString(),
                    CourseName = c.Title
                }).ToListAsync();

                return View(dto);
            }

            var studentCourses = dto.SelectedCourseIds!.Select(courseId => new StudentCourse
            {
                StudentId = Guid.Parse(dto.SelectedStudentId!),
                CourseId = Guid.Parse(courseId)
            }).ToList();

            await _dbContext.StudentCourses.AddRangeAsync(studentCourses);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentCourse studentCourse)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StudentCourse studentCourse)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
