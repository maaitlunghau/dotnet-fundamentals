using System.ComponentModel.DataAnnotations;

namespace _11_dto_automapper_authentication.Models;

public class Account
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int? Age { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập role!")]
    [RegularExpression(@"^(ADMIN|USER)$", ErrorMessage = "Role chỉ là admin hoặc user thôi!")]
    public string? Role { get; set; }

    public DateTime CreatedAt { get; set; }
}
