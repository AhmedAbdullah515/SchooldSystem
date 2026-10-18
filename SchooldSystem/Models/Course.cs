using System.ComponentModel.DataAnnotations;

namespace SchooldSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        [StringLength(100), MinLength(3)]
        public string Title { get; set; }
        [Required]
        [Range(1, 6)]
        public int CreditHours { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
