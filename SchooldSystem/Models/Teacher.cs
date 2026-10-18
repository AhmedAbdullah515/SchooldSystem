using System.ComponentModel.DataAnnotations;

namespace SchooldSystem.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        [StringLength(100), MinLength(3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
