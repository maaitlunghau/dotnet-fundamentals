using _10_dto_many_to_many.Models;

namespace _10_dto_many_to_many.DTO;

public class StudentAssignCourseDTO
{
    public string? SelectedStudentId { get; set; }
    public List<string>? SelectedCourseId { get; set; }

    public List<StudentDTO>? Students { get; set; }
    public List<CourseDTO>? Courses { get; set; }
}
