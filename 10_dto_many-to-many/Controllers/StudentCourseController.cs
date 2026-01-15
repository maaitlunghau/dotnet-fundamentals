using _10_dto_many_to_many.DTO;
using _10_dto_many_to_many.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _10_dto_many_to_many.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly DataContext _dbContext;
        public StudentCourseController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

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
