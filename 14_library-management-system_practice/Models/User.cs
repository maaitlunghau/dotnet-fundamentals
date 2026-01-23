using System.ComponentModel.DataAnnotations;

namespace _14_library_management_system_practice.Models;

public class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "Tên đăng nhập không được phép bỏ trống!")]
    [StringLength(20, ErrorMessage = "Tên đăng nhập không được quá 20 kí tự!")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được để trống!")]
    [StringLength(20, ErrorMessage = "Mật khẩu không được quá 20 kí tự!")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập role!")]
    [RegularExpression(@"^(admin|guest)$", ErrorMessage = "Role chỉ là admin hoặc user thôi!")]
    [MaxLength(10, ErrorMessage = "Vai trò người dùng không được nhiều hơn 6 kí tự!")]
    public string? Role { get; set; }
}
