using System.ComponentModel.DataAnnotations;

namespace _12_dto_automapper_announcement.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();


    [Required(ErrorMessage = "Tên người dùng không được bỏ trống!")]
    public string? Username { get; set; }


    [Required(ErrorMessage = "Email không được bỏ trống!")]
    public string? Email { get; set; }


    [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
    public string? Password { get; set; }


    [Required(ErrorMessage = "Tuổi của bạn không được bỏ trống!")]
    public int? Age { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
}
