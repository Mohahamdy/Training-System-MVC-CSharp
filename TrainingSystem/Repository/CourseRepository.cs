using Microsoft.EntityFrameworkCore;
using TrainingSystem.Models;

namespace TrainingSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        TrainingSystemContext context;
        public CourseRepository(TrainingSystemContext context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.Remove(GetById(id));
        }

        public List<Course> GetAll()
        {
            return context.Courses.Include(c=>c.department).ToList();
        }

        public Course GetById(int id)
        {
             return context.Courses.Include(c=>c.department).FirstOrDefault(c=>c.Id== id);
        }

        public void Insert(Course course)
        {
            context.Add(course);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Update(Course course)
        {
            context.Update(course);
        }
    }
}
