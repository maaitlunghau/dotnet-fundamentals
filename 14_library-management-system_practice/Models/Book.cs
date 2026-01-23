using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _14_library_management_system_practice.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int BookId { get; set; }

    [Required(ErrorMessage = "Tiêu đề sách không được bỏ trống!")]
    [StringLength(100, ErrorMessage = "Tiêu đề sách không được vượt quá 100 ký tự!")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Tên tác giả không được bỏ trống!")]
    [StringLength(50, ErrorMessage = "Tên tác giả không được quá 50 kí tự!")]
    public string? Author { get; set; }

    [StringLength(13, ErrorMessage = "ISBN không được quá 13 kí tự!")]
    public string? ISBN { get; set; }

    [Required(ErrorMessage = "Tình trạng sách không được phép bỏ trống!")]
    [StringLength(10, ErrorMessage = "Tình trạng sách không được quá 10 kí tự!")]
    public string? Availability { get; set; }
}
