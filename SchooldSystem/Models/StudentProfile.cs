using System.ComponentModel.DataAnnotations;

namespace SchooldSystem.Models
{
    public class StudentProfile
    {
        public int StudentProfileId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Adress { get; set; }
        [Required]
        [Phone]
        public string ParentPhone { get; set; }
        [Required]
        [Phone]
        public string EmergencyContact { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
