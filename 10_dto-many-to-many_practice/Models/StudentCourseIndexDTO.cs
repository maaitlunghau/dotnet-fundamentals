namespace _10_dto_many_to_many_practice.Models;

public class StudentCourseIndexDTO
{
    public string? StudentId { get; set; }
    public string? StudentName { get; set; }
    public List<string>? Courses { get; set; }
}
