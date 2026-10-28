using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(
          DbContextOptions<SchoolContext> options)
          : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Major> Majors { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>()
                .ToTable("Major");

            modelBuilder.Entity<Course>()
                .ToTable("Course");

            modelBuilder.Entity<Learner>()
                .ToTable("Learner");

            modelBuilder.Entity<Enrollment>()
                .ToTable("Enrollment");
        }
    }
}
