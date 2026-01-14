namespace _10_dto_many_to_many.Models;

public class StudentCourse
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public Student? Student { get; set; }
    public Course? Course { get; set; }
}
