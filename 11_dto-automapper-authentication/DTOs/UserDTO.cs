using System.ComponentModel.DataAnnotations;

namespace _11_dto_automapper_authentication.DTOs;

public class UserDTO
{
    // tạm thời dùng giống model Account cho đơn giản vấn đề
    // cài thêm automapper để code DTO automapper

    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Trạng thái không được bỏ trống!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Tuổi của bạn không được bỏ trống!")]
    [Range(18, 100, ErrorMessage = "Tuổi phải lớn hơn 18 và nhỏ hơn 100")]
    public int? Tuoi { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập role!")]
    [RegularExpression(@"^(ADMIN|USER)$", ErrorMessage = "Role chỉ là admin hoặc user thôi!")]
    public string? Role { get; set; }

    [Required(ErrorMessage = "Trạng thái người dùng không được bỏ trống!")]
    [RegularExpression(@"^(Active|Banned)$", ErrorMessage = "Trạng thái chỉ là Active hoặc Banned!")]
    public string? Status { get; set; } = "Active";

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
