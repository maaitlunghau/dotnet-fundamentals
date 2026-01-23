using System.ComponentModel.DataAnnotations;

namespace _13_school_management_system_practice.Attribute;

public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult("Ngày sinh không được bỏ trống!");

        if (value is DateTime date && date.Date >= DateTime.Today)
            return new ValidationResult("Ngày sinh phải nhỏ hơn ngày hiện tại!");

        return ValidationResult.Success;
    }
}
