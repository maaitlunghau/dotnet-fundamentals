namespace _10_dto_many_to_many_practice.Models;

public class StudentCourseCreateDTO
{
    public string? SelectedStudentId { get; set; }
    public List<string>? SelectedCourseIds { get; set; }

    // field (not relationship)
    // thiết lập 2 field này để:
    //      + đem tất cả sinh viên lên form Create (dùng Select or vòng lặp)
    //      + đem tất cả khoá học lên form Create (dùng Select or vòng lặp)
    public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();
    public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
}
