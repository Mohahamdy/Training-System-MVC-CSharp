using Microsoft.EntityFrameworkCore;

namespace TrainingSystem.Models
{
    public class TrainingSystemContext : DbContext
    {
        public TrainingSystemContext() : base(){}

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<CrsResult> CrsResults{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TrainingSystem;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
