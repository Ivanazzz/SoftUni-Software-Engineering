using System.Reflection;

namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    using Common;
    using Models;



    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Resource> Resources { get; set; } = null!;

        public DbSet<Homework> Homeworks { get; set; } = null!;

        public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
            });

            modelBuilder
                .Entity<Student>()
                .Property(s => s.Name)
                .HasColumnType("NVARCHAR");

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Name)
                .HasColumnType("NVARCHAR");

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Description)
                .HasColumnType("NVARCHAR");

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Name)
                .HasColumnType("NVARCHAR");
        }
    }
}