using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingSystem.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImgUrl { get; set; }
        public int Grade { get; set; }
        public string? Address { get; set; }

        [ForeignKey("department")]
        public int Dept_Id { get; set; }

        public Department department { get; set; }

        public List<CrsResult> crsResults { get; set; }
    }
}
