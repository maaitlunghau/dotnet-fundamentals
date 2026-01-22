using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _14_library_management_system.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên sách không được bỏ trống!")]
    [StringLength(100, ErrorMessage = "Tên sách không được vượt quá 100 ký tự!")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Tên tác giả không được bỏ trống!")]
    [StringLength(50, ErrorMessage = "Tên tác giả không được vượt quá 50 ký tự!")]
    public string? Author { get; set; }

    [Required(ErrorMessage = "ISBN không được bỏ trống!")]
    [StringLength(13, ErrorMessage = "ISBN không được vượt quá 13 ký tự!")]
    public string? ISBN { get; set; }

    [Required(ErrorMessage = "Tình trạng của sách không được bỏ trống!")]
    [StringLength(20, ErrorMessage = "Tình trạng của sách không được vượt quá 20 ký tự!")]
    public string? Availability { get; set; }
}
