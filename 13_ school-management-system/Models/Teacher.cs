using System.ComponentModel.DataAnnotations;

namespace _13__school_management_system.Models
{
    public class Teacher
    {
        [Key]
        public Guid TeacherId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(60)]
        public string TeacherName { get; set; } = null!;

        [StringLength(50)]
        public string? Department { get; set; }

        [StringLength(40)]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
