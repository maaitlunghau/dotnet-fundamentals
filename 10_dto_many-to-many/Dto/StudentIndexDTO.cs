namespace _10_dto_many_to_many.DTO;

public class StudentIndexDTO
{
    public string? StudentId { get; set; }
    public string? Name { get; set; }
    public List<string>? Courses { get; set; }
}
