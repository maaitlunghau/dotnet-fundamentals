using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _14_library_management_system.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập username!")]
    [MaxLength(20, ErrorMessage = "Username không được nhiều hơn 20 kí tự")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
    [MaxLength(20, ErrorMessage = "Mật khẩu không được nhiều hơn 6 kí tự!")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập role!")]
    [RegularExpression(@"^(admin|guest)$", ErrorMessage = "Role chỉ là admin hoặc user thôi!")]
    [MaxLength(10, ErrorMessage = "Vai trò người dùng không được nhiều hơn 6 kí tự!")]
    public string? Role { get; set; }
}
