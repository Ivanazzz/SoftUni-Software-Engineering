namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Course
    {
        public Course()
        {
            StudentsCourses = new HashSet<StudentCourse>();
            Homeworks = new HashSet<Homework>();
            Resources = new HashSet<Resource>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CourseNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ValidationConstants.CourseDescriptionMaxLength)]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
