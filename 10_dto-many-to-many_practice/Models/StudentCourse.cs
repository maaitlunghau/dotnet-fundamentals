namespace _10_dto_many_to_many_practice.Models;

// model StudentCourse: 
// -- bảng trung gian giữa Student và Course
// -- đại diện cho một sinh viên đăng ký một khoá học.
// -- giải quyết vấn đề many-to-many
//
// có thể mở rộng thêm field để lưu thời gian đăng ký, số điểm, đã hoàn thành hay chưa

public class StudentCourse
{
    // fields
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }

    // relationship
    public Student? Student { get; set; }
    public Course? Course { get; set; }
}