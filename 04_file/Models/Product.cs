using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _04_file;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    [Range(10, 100)]
    public decimal Price { get; set; }

    public string? FilePath { get; set; }
    // lưu trữ đường dẫn file dô database

    [NotMapped]
    // when have this attribute, 
    // EF Core will ignore this field when creating database table
    public IFormFile? ImageFile { get; set; }
    // to work with File Upload
    // phụ trách việc lấy file thôi
}
