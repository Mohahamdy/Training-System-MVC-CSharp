using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingSystem.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("trainee")]
        public int Trainee_Id { get; set; }
        public Trainee trainee { get; set; }

        [ForeignKey("course")]
        public int Crs_Id { get; set; }
        public Course course { get; set; }
    }
}
