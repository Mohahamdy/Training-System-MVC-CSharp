using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingSystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImgUrl { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("department")]
        public int Dept_Id { get; set; }

        [ForeignKey("course")]
        public int Crs_Id { get; set; }

        public Department department { get; set; }
        public Course course { get; set; }
    }
}
