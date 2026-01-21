using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13__school_management_system.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(60)]
        public string StudentName { get; set; } = null!;

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        [ForeignKey("Teacher")]
        public Guid? TeacherId { get; set; }

        public Teacher? Teacher { get; set; }
    }
}
