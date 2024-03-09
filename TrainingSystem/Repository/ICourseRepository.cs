using TrainingSystem.Models;

namespace TrainingSystem.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();
        public Course GetById(int id);
        public void Insert(Course course);
        public void Update(Course course);
        public void Delete(int id);
        public int Save();
    }
}
