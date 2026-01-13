using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_file_handling.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống!")]
    [StringLength(maximumLength: 100, ErrorMessage = "Tên sản phẩm chỉ tối đa được 100 ký tự!")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Giá sản phẩm không được bỏ trống!")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(10, 1000, ErrorMessage = "Giá sản phẩm phải từ 10 đến 1000 đô la Mỹ ($)")]
    public decimal Price { get; set; }

    [DataType(DataType.MultilineText)]
    [StringLength(maximumLength: 500, ErrorMessage = "Mô tả sản phẩm tối đa chỉ được 500 ký tự!")]
    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    [NotMapped] // kh lưu field Image này vào Database
    [Display(Name = "Hình ảnh của sản phẩm")]
    public IFormFile? Image { get; set; }
    // file Image này: quan trọng nhất cho FILE HANDLING
    // đóng vai trò là file trung gian chứ kh phải để lưu

    // Workflow: 
    // Browser -> multipart/form-data -> ASP.NET (Model Binding) -> IFormFile Image (RAM)
    // Image (RAM): 
    //      + nhận file từ FORM
    //      + kiểm tra (có upload không / dung lượng / định dạng / cloud... )
    //      + gán tên Image cho ImageUrl và lưu dô database
}
