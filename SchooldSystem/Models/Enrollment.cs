using System.ComponentModel.DataAnnotations;

namespace SchooldSystem.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
       
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Range(0, 100)]
        public decimal? Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
