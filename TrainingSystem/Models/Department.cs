namespace TrainingSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Manager { get; set; }

        public List<Instructor> instructors { get; set; }

        public List<Trainee> trainees { get; set; }
    }
}
