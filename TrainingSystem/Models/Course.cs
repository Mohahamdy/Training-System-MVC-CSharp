using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [Unique]
        public string Name { get; set; }

        [Range(50,100,ErrorMessage ="Degree Must be between 50 and 100")]
        public int Degree { get; set; }

        [Remote("CheckMinDegreeLessThanDegree","Course",ErrorMessage ="Min Degree Must be less than Degree",AdditionalFields ="Degree")]
        public int MinDegree { get; set; }

        [ForeignKey("department")]
        [Display(Name ="Department")]
        public int Dept_Id { get; set; }
        public Department? department { get; set; }

        public List<Instructor>? instructors { get; set; }

        public List<CrsResult>? crsResults { get; set; }
    }
}
