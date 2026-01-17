using System.ComponentModel.DataAnnotations;

namespace _12_dto_automapper_announcement.Models;

public class Announcement
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Tiêu đề tin thông báo không được bỏ trống!")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Nội dung tin thông báo không được bỏ trống!")]
    public string? Content { get; set; }

    public enum AnnouncementCategory
    {
        [Display(Name = "Cập nhật")]
        Update,

        [Display(Name = "Hướng dẫn")]
        Guide,

        [Display(Name = "Dịch vụ")]
        Service,

        [Display(Name = "Thanh toán")]
        Payment
    }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public User? User { get; set; }
}
