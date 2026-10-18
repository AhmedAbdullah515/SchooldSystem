using Microsoft.EntityFrameworkCore;
using SchooldSystem.Models;

namespace SchooldSystem.App_context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //primarykeys
            modelBuilder.Entity<Student>().HasKey(a => a.StudentId);
            modelBuilder.Entity<Teacher>().HasKey(a => a.TeacherId);
            modelBuilder.Entity<Course>().HasKey(a => a.CourseId);
            modelBuilder.Entity<Enrollment>().HasKey(a => a.EnrollmentId);
            modelBuilder.Entity<StudentProfile>().HasKey(a => a.StudentProfileId);
            //relations
            modelBuilder.Entity<Course>().HasOne(a => a.Teacher).WithMany(a => a.Courses).HasForeignKey(a => a.TeacherId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentProfile>().HasOne(a => a.Student).WithOne(a => a.StudentProfile).HasForeignKey<StudentProfile>(a => a.StudentId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Enrollment>().HasOne(a => a.Student).WithMany(a => a.Enrollments).HasForeignKey(a => a.StudentId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Enrollment>().HasOne(a => a.Course).WithMany(a => a.Enrollments).HasForeignKey(a => a.CourseId).OnDelete(DeleteBehavior.Cascade);
            //requirments
            modelBuilder.Entity<Student>().Property(a => a.Email).IsRequired();
            modelBuilder.Entity<Teacher>().Property(a => a.Email).IsRequired();
            modelBuilder.Entity<StudentProfile>().Property(a => a.StudentId).IsUnicode();
            modelBuilder.Entity<Enrollment>().HasIndex(a => new { a.StudentId, a.CourseId }).IsUnique();
            //Data Seeding
            // 1. Seed Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, FullName = "Ahmed Samir", Email = "ahmed.samir@school.com", Phone = "01044444444", HireDate = new DateTime(2020, 9, 1) },
                new Teacher { TeacherId = 2, FullName = "Nour Adel", Email = "nour.adel@school.com", Phone = "01055555555", HireDate = new DateTime(2021, 2, 15) },
                new Teacher { TeacherId = 3, FullName = "Hany Mostafa", Email = "hany.mostafa@school.com", Phone = "01066666666", HireDate = new DateTime(2019, 8, 20) }
            );

           

            // تصحيح سطر Student 3 لتجنب أي لخبطة:
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, FullName = "Ali Hassan", Email = "ali.hassan@school.com", Phone = "01011111111", BirthDate = new DateTime(2010, 5, 12), Gender = "Male" },
                new Student { StudentId = 2, FullName = "Mariam Ahmed", Email = "mariam.ahmed@school.com", Phone = "01022222222", BirthDate = new DateTime(2010, 8, 20), Gender = "Female" },
                new Student { StudentId = 3, FullName = "Omar Khaled", Email = "omar.khaled@school.com", Phone = "01033333333", BirthDate = new DateTime(2009, 11, 5), Gender = "Male" }
            );

            // 3. Seed StudentProfiles
            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile { StudentProfileId = 1, Adress = "Nasr City, Cairo", ParentPhone = "01111111111", EmergencyContact = "01211111111", StudentId = 1 },
                new StudentProfile { StudentProfileId = 2, Adress = "Heliopolis, Cairo", ParentPhone = "01122222222", EmergencyContact = "01222222222", StudentId = 2 },
                new StudentProfile { StudentProfileId = 3, Adress = "Maadi, Cairo", ParentPhone = "01133333333", EmergencyContact = "01233333333", StudentId = 3 }
            );

            // 4. Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Title = "Programming Fundamentals", CreditHours = 3, TeacherId = 1 },
                new Course { CourseId = 2, Title = "Database Systems", CreditHours = 4, TeacherId = 2 },
                new Course { CourseId = 3, Title = "Web Development", CreditHours = 3, TeacherId = 1 }
            );

            // 5. Seed Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1, EnrollmentDate = new DateTime(2026, 9, 1), Grade = 90.00m },
                new Enrollment { EnrollmentId = 2, StudentId = 2, CourseId = 2, EnrollmentDate = new DateTime(2026, 9, 2), Grade = 85.50m },
                new Enrollment { EnrollmentId = 3, StudentId = 3, CourseId = 3, EnrollmentDate = new DateTime(2026, 9, 3), Grade = null }
            );
        }
    }

    
}
